using System.Drawing;

namespace WindowClicker.Models
{
	public class ProcessAction
	{
		public string ActionType { get; set; }

		public int ClickRadius { get; set; }

		/// <summary>
		/// Delay between clicks
		/// </summary>
		public Range ClickRange { get; set; }

		/// <summary>
		/// Number of clicks
		/// </summary>
		public Range ClicksRange { get; set; }

		/// <summary>
		/// Time to wait between actions
		/// </summary>
		public Range DelayRange { get; set; }

		public Point Location { get; set; }

		public string Name { get; set; }

		public override string ToString()
		{
			return $"{Name}: ({Location.X},{Location.Y}) {{{ClickRange}}} [{ClicksRange}] ~[{DelayRange}]";
		}
	}
}