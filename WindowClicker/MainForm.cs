using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WindowClicker.Models;

namespace WindowClicker
{
	public partial class MainForm : Form
	{
		private const int MAX_DURATIONS_SAMPLE = 10;
		private const string TIMESPAN_FORMAT = "hh\\:mm\\:ss";

		bool _isStarted;
		DateTime? _lastClickTime;
		List<TimeSpan> _lastDurations;
		TimeSpan _minDuration;
		List<ProcessAction> _actions;
		DateTime _startClickTime;
		int _testClicks;

		public MainForm()
		{
			InitializeComponent();

			_actions = new List<ProcessAction>();
			//_maxDuration = TimeSpan.MinValue;
			_lastDurations = new List<TimeSpan>();
			_minDuration = TimeSpan.MaxValue;

			iterationClicksMin_Leave(null, null);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		//----==== EVENTS ====---------------------------------------------------------------------------

		private void cActionList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cActionList.SelectedIndex >= 0)
			{
				cUpdateAction.Enabled = true;

				// Fill in fields based on the selcted action.
				// This is what we had to do BEFORE MVVM magic.

				var action = _actions[cActionList.SelectedIndex];

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
		}

		private void cAddAction_Click(object sender, EventArgs e)
		{
			var action = ConstructAction();

			if (action != null)
			{
				// TODO: Possibly don't need this list and just store object in the action list.

				_actions.Add(action);

				cActionList.Items.Add(action);

				cUseActions.Enabled = true;
			}
		}

		private void cUpdateAction_Click(object sender, EventArgs e)
		{
			if (cActionList.SelectedIndex >= 0)
			{
				var action = ConstructAction();

				// Replace the selected action.

				var selectedIndex = cActionList.SelectedIndex;

				_actions[selectedIndex] = action;

				cActionList.Items.RemoveAt(selectedIndex);
				cActionList.Items.Insert(selectedIndex, action);
				cActionList.SelectedIndex = selectedIndex;			// Select updated item. (removal and insert deselects selected item).
			}
		}

		private void clickScreen_Click(object sender, EventArgs e)
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

			var iterMax = int.Parse(cIterationCount.Text);

			var singleAction = ConstructAction();

			var cDetail = 0;
			var cTotal = 0;
			var progressOffset = 0;
			var duration = 0;
			var random = new Random();

			progressBar.Minimum = 0;

			// Initial maximum is based on the iterations * the average of the number of clicks (not really time based)
			progressBar.Maximum = iterMax * (singleAction.ClicksRange.Min + singleAction.ClicksRange.Max) / 2;

			for (int iteration = 1; iteration <= iterMax && _isStarted; iteration++)
			{
				var clicksMax = 0;

				if (cUseActions.Checked)
				{
					var selectedIndex = 0;

					foreach (var action in _actions)
					{
						cActionList.SelectedIndex = selectedIndex++;

						ProcessAction(action, iteration, ref clicksMax, ref cTotal);

						// Wait between actions

						WaitWhileHandlingEvents(random.Next(action.DelayRange.Min, action.DelayRange.Max));
					}
				}
				else
				{
					ProcessAction(singleAction, iteration, ref clicksMax, ref cTotal);

					if (iteration != iterMax)
					{
						// Wait between iterations

						WaitWhileHandlingEvents(random.Next(singleAction.DelayRange.Min, singleAction.DelayRange.Max));
					}
				}

				clickDetail.Text = $"{duration} / {cDetail / cTotal}";
				iterationClicksDetail.Text = $"{clicksMax} / {clicksMax / cTotal}";

				Application.DoEvents();

				progressOffset += clicksMax;
			}

			waiting.Text = string.Empty;

			progressBar.Value = 0;      // Turn "off"
			_isStarted = false;
			cClickScreen.Text = "Click Screen";
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

					_startClickTime = now;
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

						clickMin.Text = _minDuration.TotalMilliseconds.ToString("N0");
					}

					if (_lastDurations.Count >= MAX_DURATIONS_SAMPLE)
					{
						_lastDurations.RemoveAt(0);
					}

					_lastDurations.Add(duration);

					clickMax.Text = _lastDurations.Max().TotalMilliseconds.ToString("N0");
					clickDetail.Text = $"{duration.TotalMilliseconds:N0} / {_lastDurations.Average(item => item.TotalMilliseconds):N0}";
				}

				iterationClicksMin.Text = _testClicks.ToString("N0");
				iterationClicksMax.Text = iterationClicksMin.Text;

				_testClicks++;
			}

			_lastClickTime = now;
		}

		//----==== PRIVATE ====---------------------------------------------------------------------------

		private ProcessAction ConstructAction()
		{
			int x, y;
			ProcessAction result = null;

			if (int.TryParse(screenX.Text, out x) && int.TryParse(screenY.Text, out y))
			{
				result = new ProcessAction
				{
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

		private void ProcessAction(ProcessAction action, int iter, ref int clicksMax, ref int totClicks)
		{
			var x = action.Location.X - action.ClickRadius;     // Shift by radius
			var y = action.Location.Y - action.ClickRadius;     // Shift by radius
			var cDetail = 0;
			var progressOffset = 0;
			var diameter = action.ClickRadius * 2;
			var iterClicksMin = action.ClicksRange.Min;
			var iterClicksMax = action.ClicksRange.Max;
			var duration = 0;
			var iterMax = int.Parse(cIterationCount.Text);
			var random = new Random();
			var timeStarted = DateTime.Now;

			clicksMax = random.Next(iterClicksMin, iterClicksMax);

			if (action.ClickRange.Min == 0 && action.ClickRange.Min == action.ClickRange.Max)
			{
				// NO delay between clicks!!

				ClickOnPointTool.ClickOnPoint(Handle, new Point(random.Next(x, x + diameter), random.Next(y, y + diameter)), clicksMax);
			}
			else
			{
				var iterStopWatch = new Stopwatch();
				var stopWatch = new Stopwatch();

				iterStopWatch.Start();

				for (int click = 1; click <= clicksMax && _isStarted; click++)
				{
					stopWatch.Restart();

					// Randomize the point around the radius.

					ClickOnPointTool.ClickOnPoint(Handle, new Point(random.Next(x, x + diameter), random.Next(y, y + diameter)));

					duration = random.Next(action.ClickRange.Min, action.ClickRange.Max);

					cDetail += duration;
					totClicks++;

					var elapsedMS = DateTime.Now.Subtract(timeStarted).TotalMilliseconds;

					progressBar.Value = progressOffset + click;

					elapsedTime.Text = new TimeSpan(0, 0, 0, 0, (int)elapsedMS).ToString(TIMESPAN_FORMAT);
					estimatedRemaining.Text = new TimeSpan(0, 0, 0, 0, (int)((double)elapsedMS / (progressOffset + click + 1) * ((iterMax - iter) * (iterClicksMin + iterClicksMax) / 2 + clicksMax - click))).ToString(TIMESPAN_FORMAT);
					clickDetail.Text = $"{duration} / {cDetail / totClicks}";
					iterationClicksDetail.Text = $"{clicksMax} / {clicksMax / clicksMax}";

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

			clickDetail.Text = $"{duration} / {cDetail / totClicks}";
			iterationClicksDetail.Text = $"{clicksMax} / {clicksMax / totClicks}";
		}

		private void WaitWhileHandlingEvents(long milliseconds)
		{
			const int WAIT_DURATION = 500;

			while (milliseconds > 0 && _isStarted)
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

			//waiting.Text = string.Empty;
		}
	}
}