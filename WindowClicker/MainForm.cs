using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

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
		DateTime _startClickTime;
		int _testClicks;

		public MainForm()
		{
			InitializeComponent();

			//_maxDuration = TimeSpan.MinValue;
			_lastDurations = new List<TimeSpan>();
			_minDuration = TimeSpan.MaxValue;

			iterationClicksMin_Leave(null, null);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		private void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			mouseX.Text = e.X.ToString();
			mouseY.Text = e.Y.ToString();
		}

		private void clickScreen_Click(object sender, EventArgs e)
		{
			if (_isStarted)
			{
				_isStarted = false;
				clickScreen.Text = "Click Screen";
				return;
			}

			clickScreen.Text = "Cancel";
			_isStarted = true;

			var x = int.Parse(screenX.Text);
			var y = int.Parse(screenY.Text);
			var cMin = int.Parse(clickMin.Text);
			var cMax = int.Parse(clickMax.Text);
			var cDetail = 0;
			var cTotal = 0;
			var progressOffset = 0;
			var wMin = int.Parse(waitMin.Text);
			var wMax = int.Parse(waitMax.Text);
			var radius = int.Parse(clickRadius.Text);
			var diameter = radius * 2;
			var iterClicksMin = int.Parse(iterationClicksMin.Text);
			var iterClicksMax = int.Parse(iterationClicksMax.Text);
			var duration = 0;
			var iterMax = int.Parse(iterationCount.Text);
			var random = new Random();
			var timeStarted = DateTime.Now;

			x -= radius;
			y -= radius;

			progressBar.Minimum = 0;
			progressBar.Maximum = iterMax * (iterClicksMin + iterClicksMax) / 2;

			for (int iter = 1; iter <= iterMax && _isStarted; iter++)
			{
				var clicksMax = random.Next(iterClicksMin, iterClicksMax);

				progressBar.Maximum = progressBar.Maximum - (iterClicksMin + iterClicksMax) / 2 + clicksMax;
				progressBar.Value = iter;

				if (cMin == 0 && cMin == cMax)
				{
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

						duration = random.Next(cMin, cMax);

						cDetail += duration;
						cTotal++;

						var elapsedMS = DateTime.Now.Subtract(timeStarted).TotalMilliseconds;

						progressBar.Value = progressOffset + click;

						elapsedTime.Text = new TimeSpan(0, 0, 0, 0, (int)elapsedMS).ToString(TIMESPAN_FORMAT);
						estimatedRemaining.Text = new TimeSpan(0, 0, 0, 0, (int)((double)elapsedMS / (progressOffset + click + 1) * ((iterMax - iter) * (iterClicksMin + iterClicksMax) / 2 + clicksMax - click))).ToString(TIMESPAN_FORMAT);
						clickDetail.Text = $"{duration} / {cDetail / cTotal}";
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

						WaitWhileHandlingEvents(duration - stopWatch.ElapsedMilliseconds);
					}
				}

				if (iter != iterMax)
				{
					WaitWhileHandlingEvents(random.Next(wMin, wMax));
				}

				clickDetail.Text = $"{duration} / {cDetail / cTotal}";
				iterationClicksDetail.Text = $"{clicksMax} / {clicksMax / cTotal}";

				Application.DoEvents();

				progressOffset += clicksMax;
			}

			waiting.Text = string.Empty;

			progressBar.Value = 0;      // Turn "off"
			_isStarted = false;
			clickScreen.Text = "Click Screen";
		}

		private void screenClickPanel_MouseClick(object sender, MouseEventArgs e)
		{
			var screenPoint = screenClickPanel.PointToScreen(e.Location);

			screenX.Text = screenPoint.X.ToString();
			screenY.Text = screenPoint.Y.ToString();

			clickScreen.Enabled = true;
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

		private void iterationClicksMin_Leave(object sender, EventArgs e)
		{
			var cWaitMin = int.Parse(clickMin.Text);
			var cWaitMax = int.Parse(clickMax.Text);
			var wMin = int.Parse(waitMin.Text);
			var wMax = int.Parse(waitMax.Text);
			var iterClicksMin = int.Parse(iterationClicksMin.Text);
			var iterClicksMax = int.Parse(iterationClicksMax.Text);
			var iterMax = int.Parse(iterationCount.Text);

			var estimatedMilliseconds = iterMax * (wMin + wMax) / 2 + (iterClicksMin + iterClicksMax + cWaitMin + cWaitMax) / 2;

			var duration = new TimeSpan(0, 0, 0, 0, estimatedMilliseconds);

			estimatedTime.Text = duration.ToString(TIMESPAN_FORMAT);
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