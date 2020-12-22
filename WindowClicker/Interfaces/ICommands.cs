using System.Collections.Generic;
using WindowClicker.Models;

namespace WindowClicker.Interfaces
{
	public interface ICommands
	{
		IList<IProcessAction> Load<TType>(string fileName) where TType : List<ProcessAction>, new();

		void Save<TType>(string fileName, TType actions) where TType : List<IProcessAction>;
	}
}