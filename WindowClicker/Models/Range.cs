using System.Runtime.Serialization;
using WindowClicker.Interfaces;

namespace WindowClicker.Models
{
	[DataContract]
	public class Range : IRange
	{
		[DataMember]
		public int Max { get; set; }

		[DataMember]
		public int Min { get; set; }

		public override string ToString()
		{
			return $"{Min}-{Max}";
		}
	}
}