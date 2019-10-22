namespace WindowClicker.Models
{
	public class Range
	{
		public int Max { get; set; }

		public int Min { get; set; }

		public override string ToString()
		{
			return $"{Min}-{Max}";
		}
	}
}