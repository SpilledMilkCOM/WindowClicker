using System.Runtime.Serialization;

namespace WindowClicker.Test
{
	[DataContract]
	public class ConcreteNoKnownType : IAbstract
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public IInner Inner { get; set; }
	}
}