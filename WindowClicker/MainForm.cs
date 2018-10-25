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
			var x = int.Parse(screenX.Text);
			var y = int.Parse(screenY.Text);
			var cMin = int.Parse(clickMin.Text);
			var cMax = int.Parse(clickMax.Text);
			var wMin = int.Parse(waitMin.Text);
			var wMax = int.Parse(waitMax.Text);
			var radius = int.Parse(clickRadius.Text);
			var diameter = radius * 2;
			var iterClicksMin = int.Parse(iterationClicksMin.Text);
			var iterClicksMax = int.Parse(iterationClicksMax.Text);
			var iterMax = int.Parse(iterationCount.Text);
			var random = new Random();

			x -= radius;
			y -= radius;

			progressBar.Minimum = 0;
			progressBar.Maximum = iterMax;

			for (int iter = 0; iter <= iterMax; iter++)
			{
				var clicksMax = random.Next(iterClicksMin, iterClicksMax);
				progressBar.Value = iter;

				for (int click = 0; click < clicksMax; click++)
				{
					// Randomize the point around the radius.

					ClickOnPointTool.ClickOnPoint(Handle, new Point(random.Next(x, x + diameter), random.Next(y, y + diameter)));

					Thread.Sleep(random.Next(cMin, cMax));
				}

				Thread.Sleep(random.Next(wMin, wMax));
			}
		}

		private void screenClickPanel_MouseClick(object sender, MouseEventArgs e)
		{
			var screenPoint = screenClickPanel.PointToScreen(e.Location);

			screenX.Text = screenPoint.X.ToString();
			screenY.Text = screenPoint.Y.ToString();
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

			var estimatedMilliseconds = iterMax * (wMin + wMax) / 2 + (iterClicksMin + iterClicksMax + cWaitMin + cWaitMax) / 4;

			var duration = new TimeSpan(0, 0, 0, 0, estimatedMilliseconds);

			estimatedTime.Text = duration.ToString();
		}
	}
}