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
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		private void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			mouseX.Text = e.X.ToString();
			mouseY.Text = e.Y.ToString();
		}

		private void MainForm_MouseClick(object sender, MouseEventArgs e)
		{
			var screenPoint = PointToScreen(e.Location);

			screenX.Text = screenPoint.X.ToString();
			screenY.Text = screenPoint.Y.ToString();
		}

		private void clickScreen_Click(object sender, EventArgs e)
		{
			var x = int.Parse(screenX.Text);
			var y = int.Parse(screenY.Text);
			var cMin = int.Parse(clickMin.Text);
			var cMax = int.Parse(clickMax.Text);
			var wMin = int.Parse(waitMin.Text);
			var wMax = int.Parse(waitMax.Text);
			var iterClicksMin = int.Parse(iterationClicksMin.Text);
			var iterClicksMax = int.Parse(iterationClicksMax.Text);
			var iterMax = int.Parse(iterationCount.Text);
			var random = new Random();

			progressBar.Minimum = 0;
			progressBar.Maximum = iterMax;

			for (int iter = 0; iter <= iterMax; iter++)
			{
				var clicksMax = random.Next(iterClicksMin, iterClicksMax);
				progressBar.Value = iter;

				for (int click = 0; click < clicksMax; click++)
				{
					ClickOnPointTool.ClickOnPoint(Handle, new Point(x, y));

					Thread.Sleep(random.Next(cMin, cMax));
				}

				Thread.Sleep(random.Next(wMin, wMax));
			}
		}
	}
}