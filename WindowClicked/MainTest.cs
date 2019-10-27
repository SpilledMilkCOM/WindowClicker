using System.Drawing;
using System.Windows.Forms;

namespace WindowClicked
{
	public partial class MainTest : Form
	{
		public MainTest()
		{
			InitializeComponent();
		}

		private void MainTest_MouseClick(object sender, MouseEventArgs e)
		{
			using (var graphics = CreateGraphics())
			{
				using (var brush = new SolidBrush(Color.Red))
				{
					graphics.FillRectangle(brush, e.X, e.Y, 1, 1);
				}
			}

			// TODO: Set a timer to erase this point in a few seconds.
		}
	}
}