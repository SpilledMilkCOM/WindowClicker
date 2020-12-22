using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Windows.Forms;
using WindowClicker.Interfaces;
using WindowClicker.Models;

namespace WindowClicker
{
	public partial class MainForm : Form
	{
		private const int CONTROL_MARGIN = 5;
		private const int MAX_DURATIONS_SAMPLE = 10;
		private const string WITH_COMMAS_FORMAT = "N0";
		private const string TIMESPAN_FORMAT = "hh\\:mm\\:ss";

		private bool _isStarted;
		private DateTime? _lastClickTime;
		private List<TimeSpan> _lastDurations;
		private TimeSpan _minDuration;
		private bool _skipAction;
		private int _testClicks;

		private ICommands _commands;

		public MainForm()
		{
			InitializeComponent();

			_lastDurations = new List<TimeSpan>();
			_minDuration = TimeSpan.MaxValue;

			iterationClicksMin_Leave(null, null);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			cStatus.Text = string.Empty;
			totalClicks.Text = "0";
			cActionCount.Text = "0";

			// Eventually use an IoC Container (for now just using DI)

			_commands = new Commands(typeof(List<IProcessAction>)
					 , new DataContractJsonSerializerSettings
					 {
						 EmitTypeInformation = EmitTypeInformation.Never,                       // Type info is pretty noisy
						 IgnoreExtensionDataObject = true,
						 KnownTypes = new List<Type> { typeof(ProcessAction), typeof(Range) }
					 }); ;
		}

		//----==== MENUS ====----------------------------------------------------------------------------

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				// Prompt for file

				if (cOpenFileDialog.ShowDialog() == DialogResult.OK)
				{
					var actions = _commands.Load<List<ProcessAction>>(cOpenFileDialog.FileName);

					cActionList.Items.Clear();

					if (actions.Any())
					{
						foreach (var item in actions)
						{
							cActionList.Items.Add(item);
						}
					}

					UpdatedActionList();

					DisplayStatus($"Loaded: {Path.GetFileName(cOpenFileDialog.FileName)}");
				}
			}
			catch (Exception ex)
			{
				DisplayError(ex, "Error Loading File");
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Prompt for file

			if (cSaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				var actions = new List<IProcessAction>();

				foreach (IProcessAction item in cActionList.Items)
				{
					actions.Add(item);
				}

				_commands.Save(cSaveFileDialog.FileName, actions);		// Generic method type is inferred from the paramter.

				cStatus.Text = $"Saved: {Path.GetFileName(cSaveFileDialog.FileName)}";
			}
		}

		//----==== EVENTS ====---------------------------------------------------------------------------

		private void cActionList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cActionList.SelectedIndex >= 0)
			{
				cUpdateAction.Enabled = true;
				cDeleteAction.Enabled = true;

				// Fill in fields based on the selcted action.
				// This is what we had to do BEFORE MVVM magic.

				var action = cActionList.SelectedItem as ProcessAction;

				cClickRadius.Text = action.ClickRadius.ToString();

				clickMax.Text = action.ClickRange.Max.ToString();
				clickMin.Text = action.ClickRange.Min.ToString();

				iterationClicksMax.Text = action.ClicksRange.Max.ToString();
				iterationClicksMin.Text = action.ClicksRange.Min.ToString();

				cWaitMax.Text = action.DelayRange.Max.ToString();
				cWaitMin.Text = action.DelayRange.Min.ToString();

				screenX.Text = action.Location.X.ToString();
				screenY.Text = action.Location.Y.ToString();
			}
			else
			{
				cUpdateAction.Enabled = false;
				cDeleteAction.Enabled = false;
			}
		}

		private void cAddAction_Click(object sender, EventArgs e)
		{
			var action = ConstructAction();

			if (action != null)
			{
				cActionList.Items.Add(action);

				UpdatedActionList();
			}
		}

		private void cClickScreen_Click(object sender, EventArgs e)
		{
			if (_isStarted)
			{
				// Cancel out of process.

				_isStarted = false;
				cClickScreen.Text = "Click Screen";
				return;
			}

			cClickScreen.Text = "Cancel";
			_isStarted = true;
			_skipAction = false;

			currentLabel.Visible = _isStarted;
			currentIteration.Visible = _isStarted;

			var iterMax = int.Parse(cIterationCount.Text);

			var singleAction = ConstructAction();

			var clickDetail = 0;
			var clickTotal = 0;
			var progressOffset = 0;
			var duration = 0;
			var random = new Random();

			cProgressBar.Minimum = 0;
			cProgressBar.Maximum = 0;

			// Initial maximum is based on the iterations * the average of the number of clicks (not really time based)

			if (cUseActions.Checked)
			{
				foreach (ProcessAction action in cActionList.Items)
				{
					cProgressBar.Maximum += (action.ClicksRange.Min + action.ClicksRange.Max) / 2;
				}

				cProgressBar.Maximum *= iterMax;
			}
			else
			{
				cProgressBar.Maximum = iterMax * (singleAction.ClicksRange.Min + singleAction.ClicksRange.Max) / 2;
			}

			if (cSavePosition.Checked)
			{
				Thread.Sleep(500);
			}

			for (int iteration = 1; iteration <= iterMax && _isStarted; iteration++)
			{
				var clicksMax = 0;

				currentIteration.Text = iteration.ToString();

				if (cUseActions.Checked)
				{
					var selectedIndex = 0;
					var actions = new List<ProcessAction>();            // Create a copy so the SelectedIndex can be set while iterating.

					foreach (ProcessAction item in cActionList.Items)
					{
						actions.Add(item);
					}

					foreach (ProcessAction action in actions)
					{
						cActionList.SelectedIndex = selectedIndex++;

						ProcessAction(action, iteration, ref clicksMax, ref clickTotal, ref progressOffset);

						// Wait between actions

						WaitWhileHandlingEvents(random.Next(action.DelayRange.Min, action.DelayRange.Max));

						// If "skip" is clicked within Process or Wait, then reset it here.

						if (_skipAction)
						{
							_skipAction = false;
						}
					}
				}
				else
				{
					ProcessAction(singleAction, iteration, ref clicksMax, ref clickTotal, ref progressOffset);

					if (iteration != iterMax)
					{
						// Wait between iterations

						WaitWhileHandlingEvents(random.Next(singleAction.DelayRange.Min, singleAction.DelayRange.Max));
					}
				}

				cClickDetail.Text = $"{duration} / {clickDetail / clickTotal}";
				//cIterationClicksDetail.Text = $"{clicksMax} / {clicksMax / clickTotal}";

				Application.DoEvents();

				//progressOffset += clicksMax;
			}

			waiting.Text = string.Empty;

			cProgressBar.Value = 0;      // Turn "off"
			_isStarted = false;
			cClickScreen.Text = "Click Screen";

			currentLabel.Visible = _isStarted;
			currentIteration.Visible = _isStarted;
		}

		private void cDeleteAction_Click(object sender, EventArgs e)
		{
			if (cActionList.SelectedIndex >= 0)
			{
				// Delete the selected action from the Action List (UI)

				var selectedIndex = cActionList.SelectedIndex;

				cActionList.Items.RemoveAt(selectedIndex);

				if (cActionList.Items.Count > 0)
				{
					if (selectedIndex >= cActionList.Items.Count)
					{
						selectedIndex = cActionList.Items.Count - 1;
					}

					cActionList.SelectedIndex = selectedIndex;
				}

				UpdatedActionList();
			}
		}

		private void cSkipAction_Click(object sender, EventArgs e)
		{
			_skipAction = true;
		}

		private void cUpdateAction_Click(object sender, EventArgs e)
		{
			if (cActionList.SelectedIndex >= 0)
			{
				var action = ConstructAction();

				// Replace the selected action.

				var selectedIndex = cActionList.SelectedIndex;
				action.Name = (cActionList.SelectedItem as ProcessAction)?.Name;

				cActionList.Items.RemoveAt(selectedIndex);
				cActionList.Items.Insert(selectedIndex, action);
				cActionList.SelectedIndex = selectedIndex;          // Select updated item. (removal and insert deselects selected item).

				saveToolStripMenuItem.Enabled = true;
			}
		}

		private void iterationClicksMin_Leave(object sender, EventArgs e)
		{
			var cWaitMin = int.Parse(clickMin.Text);
			var cWaitMax = int.Parse(clickMax.Text);
			var wMin = int.Parse(this.cWaitMin.Text);
			var wMax = int.Parse(this.cWaitMax.Text);
			var iterClicksMin = int.Parse(iterationClicksMin.Text);
			var iterClicksMax = int.Parse(iterationClicksMax.Text);
			var iterMax = int.Parse(cIterationCount.Text);

			var estimatedMilliseconds = iterMax * (wMin + wMax) / 2 + (iterClicksMin + iterClicksMax + cWaitMin + cWaitMax) / 2;

			var duration = new TimeSpan(0, 0, 0, 0, estimatedMilliseconds);

			estimatedTime.Text = duration.ToString(TIMESPAN_FORMAT);
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			// "Dock" botton controls

			var bottom = ClientSize.Height - cStatusStrip.Size.Height - CONTROL_MARGIN;

			cActionList.Size = new Size(cActionList.Size.Width, bottom - cActionList.Location.Y);
			cClickScreen.Location = new Point(cClickScreen.Location.X, bottom - cClickScreen.Size.Height);
		}

		private void screenClickPanel_MouseClick(object sender, MouseEventArgs e)
		{
			var screenPoint = screenClickPanel.PointToScreen(e.Location);

			screenX.Text = screenPoint.X.ToString();
			screenY.Text = screenPoint.Y.ToString();

			cClickScreen.Enabled = true;
		}

		private void TestClickPanel_MouseClick(object sender, MouseEventArgs e)
		{
			var now = DateTime.Now;

			if (_lastClickTime.HasValue)
			{
				if (_lastClickTime.Value.AddSeconds(5) < now)
				{
					// Reset if waited longer than 5 seconds.

					_testClicks = 0;
					//_maxDuration = TimeSpan.MinValue;
					_lastDurations.Clear();
					_minDuration = TimeSpan.MaxValue;
				}
				else
				{
					var duration = now.Subtract(_lastClickTime.Value);

					if (duration < _minDuration)
					{
						_minDuration = duration;

						clickMin.Text = _minDuration.TotalMilliseconds.ToString(WITH_COMMAS_FORMAT);
					}

					if (_lastDurations.Count >= MAX_DURATIONS_SAMPLE)
					{
						_lastDurations.RemoveAt(0);
					}

					_lastDurations.Add(duration);

					clickMax.Text = _lastDurations.Max().TotalMilliseconds.ToString(WITH_COMMAS_FORMAT);
					cClickDetail.Text = $"{duration.TotalMilliseconds:N0} / {_lastDurations.Average(item => item.TotalMilliseconds):N0}";
				}

				iterationClicksMin.Text = _testClicks.ToString(WITH_COMMAS_FORMAT);
				iterationClicksMax.Text = iterationClicksMin.Text;

				_testClicks++;
			}

			_lastClickTime = now;
		}

		//----==== PRIVATE ====---------------------------------------------------------------------------

		/// <summary>
		/// Construct a ProcessAction from the UI.
		/// </summary>
		/// <returns>ProcessAction</returns>
		private ProcessAction ConstructAction()
		{
			int x, y;
			ProcessAction result = null;

			if (int.TryParse(screenX.Text, out x) && int.TryParse(screenY.Text, out y))
			{
				result = new ProcessAction
				{
					ActionType = "ButtonClick",
					ClickRadius = int.Parse(cClickRadius.Text),
					ClickRange = new Range { Max = int.Parse(clickMax.Text), Min = int.Parse(clickMin.Text) },
					ClicksRange = new Range { Max = int.Parse(iterationClicksMax.Text), Min = int.Parse(iterationClicksMin.Text) },
					DelayRange = new Range { Max = int.Parse(cWaitMax.Text), Min = int.Parse(cWaitMin.Text) },
					Location = new Point(x, y),
					Name = $"Action {cActionList.Items.Count + 1}"
				};
			}

			return result;
		}

		/// <summary>
		/// Display an exception and error to the user.
		/// </summary>
		/// <param name="ex">Exception</param>
		/// <param name="message">Message to be displayed.</param>
		private void DisplayError(Exception ex, string message)
		{
			MessageBox.Show(ex.Message, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void DisplayStatus(string status)
		{
			cStatus.Text = status;
		}

		private void ProcessAction(ProcessAction action, int iter, ref int clicksMax, ref int totClicks, ref int progressOffset)
		{
			var x = action.Location.X - action.ClickRadius;     // Shift by radius (more like a box versus a radius)
			var y = action.Location.Y - action.ClickRadius;     // Shift by radius
			var clickDetail = 0;
			var diameter = action.ClickRadius * 2;
			var iterClicksMin = action.ClicksRange.Min;
			var iterClicksMax = action.ClicksRange.Max;
			var iterMax = int.Parse(cIterationCount.Text);
			var random = new Random();
			var timeStarted = DateTime.Now;

			if (iterClicksMin > iterClicksMax)
			{
				Swap(ref iterClicksMin, ref iterClicksMax);
			}

			clicksMax = random.Next(iterClicksMin, iterClicksMax);

			if (action.ClickRange.Min == 0 && action.ClickRange.Min == action.ClickRange.Max)
			{
				// NO delay between clicks!!

				ClickOnPointTool.ClickOnPoint(Handle, new Point(random.Next(x, x + diameter), random.Next(y, y + diameter)), cSavePosition.Checked, clicksMax);
			}
			else
			{
				var iterStopWatch = new Stopwatch();
				var stopWatch = new Stopwatch();

				iterStopWatch.Start();

				for (int click = 1; click <= clicksMax && _isStarted; click++)
				{
					stopWatch.Restart();

					if (action.ActionType == "ButtonClick")
					{
						// Randomize the point around the radius.

						ClickOnPointTool.ClickOnPoint(Handle, new Point(random.Next(x, x + diameter), random.Next(y, y + diameter)), cSavePosition.Checked);
					}
					else
					{
						ClickOnPointTool.VerticalWheel(Handle, new Point(x + action.ClickRadius, y + action.ClickRadius), 5);
					}

					var duration = random.Next(action.ClickRange.Min, action.ClickRange.Max);

					clickDetail += duration;
					totClicks++;

					var elapsedMS = DateTime.Now.Subtract(timeStarted).TotalMilliseconds;

					if (progressOffset + click > cProgressBar.Maximum)
					{
						cProgressBar.Maximum = progressOffset + click + 10;
					}
					cProgressBar.Value = progressOffset + click;

					elapsedTime.Text = new TimeSpan(0, 0, 0, 0, (int)elapsedMS).ToString(TIMESPAN_FORMAT);
					estimatedRemaining.Text = new TimeSpan(0, 0, 0, 0, (int)((double)elapsedMS / (progressOffset + click + 1) * ((iterMax - iter) * (iterClicksMin + iterClicksMax) / 2 + clicksMax - click))).ToString(TIMESPAN_FORMAT);
					cClickDetail.Text = $"{duration} / {clickDetail / click}";
					cIterationClicksDetail.Text = $"{click} / {clicksMax}";

					if (iterMax > 1)
					{
						var waitingText = new TimeSpan(0, 0, 0, 0, (int)(iterStopWatch.ElapsedMilliseconds / click * (clicksMax - click))).ToString(TIMESPAN_FORMAT);

						if (waitingText != waiting.Text)
						{
							// Show progress for each iteration.
							waiting.BackColor = Color.LightGreen;
							waiting.Text = waitingText;
						}
					}

					Application.DoEvents();

					// After all the work has been done, then make up the time here.

					stopWatch.Stop();

					totalClicks.Text = totClicks.ToString();

					WaitWhileHandlingEvents(duration - stopWatch.ElapsedMilliseconds);      // Between each click.
				}
			}

			cIterationClicksDetail.Text = $"{clicksMax} / {clicksMax}";     // Signals the end.

			progressOffset += clicksMax;
		}

		private void Swap<T>(ref T lhs, ref T rhs)
		{
			T temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		private void UpdatedActionList()
		{
			cActionCount.Text = cActionList.Items.Count.ToString();

			var hasItems = cActionList.Items.Count > 0;

			cUseActions.Checked = hasItems;
			cUseActions.Enabled = hasItems;
			cClickScreen.Enabled = hasItems;

			saveToolStripMenuItem.Enabled = hasItems;
		}

		private void WaitWhileHandlingEvents(long milliseconds)
		{
			const int WAIT_DURATION = 500;

			while (milliseconds > 0 && _isStarted && !_skipAction)
			{
				if (milliseconds < WAIT_DURATION)
				{
					Thread.Sleep((int)milliseconds);
				}
				else
				{
					waiting.BackColor = Color.Pink;
					waiting.Text = new TimeSpan(0, 0, 0, 0, (int)milliseconds).ToString(TIMESPAN_FORMAT);

					Application.DoEvents();

					Thread.Sleep(WAIT_DURATION);
				}

				milliseconds -= WAIT_DURATION;
			}
		}

	}
}