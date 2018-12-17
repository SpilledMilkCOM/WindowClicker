using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WindowClicker
{
	public partial class MainForm : Form
	{
		bool _isStarted;
		DateTime? _lastClickTime;
		TimeSpan _maxDuration;
		TimeSpan _minDuration;
		DateTime _startClickTime;
		int _testClicks;

		public MainForm()
		{
			InitializeComponent();

			_maxDuration = TimeSpan.MinValue;
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
			var wMin = int.Parse(waitMin.Text);
			var wMax = int.Parse(waitMax.Text);
			var radius = int.Parse(clickRadius.Text);
			var diameter = radius * 2;
			var iterClicksMin = int.Parse(iterationClicksMin.Text);
			var iterClicksMax = int.Parse(iterationClicksMax.Text);
			var iTotal = 0;
			var duration = 0;
			var iterMax = int.Parse(iterationCount.Text);
			var random = new Random();
			var timeStarted = DateTime.Now;

			x -= radius;
			y -= radius;

			progressBar.Minimum = 0;

			if (iterMax > 1)
			{
				progressBar.Maximum = iterMax;
			}

			for (int iter = 1; iter <= iterMax && _isStarted; iter++)
			{
				var clicksMax = random.Next(iterClicksMin, iterClicksMax);
				iTotal++;

				if (iterMax <= 1)
				{
					progressBar.Maximum = clicksMax;
				}
				progressBar.Value = iter;

				if (cMin == 0 && cMin == cMax)
				{
					ClickOnPointTool.ClickOnPoint(Handle, new Point(random.Next(x, x + diameter), random.Next(y, y + diameter)), clicksMax);
				}
				else
				{
					for (int click = 1; click <= clicksMax && _isStarted; click++)
					{
						// Randomize the point around the radius.

						ClickOnPointTool.ClickOnPoint(Handle, new Point(random.Next(x, x + diameter), random.Next(y, y + diameter)));

						duration = random.Next(cMin, cMax);

						Thread.Sleep(duration);

						cDetail += duration;
						cTotal++;

						if (iterMax <= 1)
						{
							var elapsedMS = DateTime.Now.Subtract(timeStarted).TotalMilliseconds;

							progressBar.Value = click;

							elapsedTime.Text = new TimeSpan(0, 0, 0, 0, (int)elapsedMS).ToString();
							estimatedRemaining.Text = new TimeSpan(0, 0, 0, 0, (int)((double)elapsedMS / (click + 1) * (clicksMax - click))).ToString();
							clickDetail.Text = $"{duration} / {cDetail / cTotal}";
							iterationClicksDetail.Text = $"{clicksMax} / {clicksMax / cTotal}";

							Application.DoEvents();
						}
					}
				}

				Thread.Sleep(random.Next(wMin, wMax));

				var elapsedMilliseconds = DateTime.Now.Subtract(timeStarted).TotalMilliseconds;
				var remainingMilliseconds = (double)elapsedMilliseconds / (iter + 1)  * (iterMax - iter);

				elapsedTime.Text = new TimeSpan(0, 0, 0, 0, (int)elapsedMilliseconds).ToString();
				estimatedRemaining.Text = new TimeSpan(0, 0, 0, 0, (int)remainingMilliseconds).ToString();
				clickDetail.Text = $"{duration} / {cDetail / cTotal}";
				iterationClicksDetail.Text = $"{clicksMax} / {clicksMax / cTotal}";

				Application.DoEvents();
			}

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
					_maxDuration = TimeSpan.MinValue;
					_minDuration = TimeSpan.MaxValue;
				}
				else
				{
					var duration = now.Subtract(_lastClickTime.Value);

					if (duration < _minDuration)
					{
						_minDuration = duration;

						clickMin.Text = _minDuration.Milliseconds.ToString();
					}

					if (duration > _maxDuration)
					{
						_maxDuration = duration;

						clickMax.Text = _maxDuration.Milliseconds.ToString();
					}
				}

				iterationClicksMax.Text = _testClicks.ToString();

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

			estimatedTime.Text = duration.ToString();
		}
	}
}