using System.Drawing;
using WindowClicker.Models;

namespace WindowClicker.Interfaces
{
	public interface IProcessAction
	{
		string ActionType { get; set; }

		int ClickRadius { get; set; }

		Range ClickRange { get; set; }

		Range ClicksRange { get; set; }

		Range DelayRange { get; set; }

		Point Location { get; set; }

		string Name { get; set; }
	}
}