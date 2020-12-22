using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using WindowClicker.Interfaces;
using WindowClicker.Models;

namespace WindowClicker
{
	/// <summary>
	/// There aren't many commands, but this class pulls them out of the form and abstracts them.
	/// </summary>

	public class Commands : ICommands
	{
		private Type _actionType;                                   // The serializer needs a concrete type.
		private DataContractJsonSerializerSettings _settings;

		public Commands(Type actionType, DataContractJsonSerializerSettings settings)
		{
			_actionType = actionType;
			_settings = settings;
		}

		public IList<IProcessAction> Load<TType>(string fileName)
			 where TType : List<ProcessAction>, new()               // This constraint is a bit harsh, but allows for casting back to an interface.
		{
			TType result = new TType();

			// Load the commands from a file.

			var serializer = new DataContractJsonSerializer(typeof(TType), _settings);

			using (var stream = File.OpenRead(fileName))
			{
				result = serializer.ReadObject(stream) as TType;
			}

			return result.Cast<IProcessAction>().ToList();
		}

		public void Save<TType>(string fileName, TType actions)
			where TType : List<IProcessAction>
		{
			// Save object to file as JSON.

			var serializer = new DataContractJsonSerializer(typeof(TType), _settings);

			// Use File Mode Create to wipe the contents of an existing file.

			using (var fileStream = File.Open(fileName, FileMode.Create))
			{
				serializer.WriteObject(fileStream, actions);
			}
		}
	}
}