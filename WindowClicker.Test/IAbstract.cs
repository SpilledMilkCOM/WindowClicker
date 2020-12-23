namespace WindowClicker.Test
{
	public interface IAbstract
	{
		string Name { get; set; }

		IInner Inner { get; set; }
	}
}
