using System.Runtime.Serialization;

namespace WindowClicker.Test
{
	[DataContract]
	[KnownType(typeof(Inner))]
	public class Concrete : IAbstract
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public IInner Inner { get; set; }
	}
}
