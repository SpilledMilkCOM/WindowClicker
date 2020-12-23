using System.Runtime.Serialization;

namespace WindowClicker.Test
{
	[DataContract(Name = "Inner")]
	public class Inner : IInner
	{
		[DataMember]
		public string Name { get; set; }
	}
}