using System.Drawing;
using System.Runtime.Serialization;
using WindowClicker.Interfaces;

namespace WindowClicker.Models
{
	[DataContract]
	[KnownType(typeof(ProcessAction))]
	[KnownType(typeof(Range))]
	public class ProcessAction : IProcessAction
	{
		[DataMember]
		public string ActionType { get; set; }

		[DataMember]
		public int ClickRadius { get; set; }

		/// <summary>
		/// Delay between clicks
		/// </summary>
		[DataMember]
		public Range ClickRange { get; set; }

		/// <summary>
		/// Number of clicks
		/// </summary>
		[DataMember]
		public Range ClicksRange { get; set; }

		/// <summary>
		/// Time to wait between actions
		/// </summary>
		[DataMember] 
		public Range DelayRange { get; set; }

		[DataMember]
		public Point Location { get; set; }

		[DataMember]
		public string Name { get; set; }

		public override string ToString()
		{
			return $"{Name}: ({Location.X},{Location.Y}) {{{ClickRange}}} [{ClicksRange}] ~[{DelayRange}]";
		}
	}
}