using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System;

namespace WindowClicker.Test
{
	/// <summary>
	/// These tests illustrate the need for "KnownTypes" on the Serializer otherwise serializing and deserializing will blow up.
	/// </summary>

	[TestClass]
	public class SerializerKnownTypesTests
	{
		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void DataContractJsonSerializer_DeserializeInnerWithNoTypeInfo()
		{
			var serializer = new DataContractJsonSerializer(typeof(ConcreteNoKnownType), new List<Type> { typeof(Inner) });

			using (var stream = CreateStream(@"{""Name"":""Concrete"", ""Inner"":{""Name"":""Test""}}"))
			{
				var actual = serializer.ReadObject(stream) as IAbstract;		// BOOM!
			}
		}

		[TestMethod]
		public void DataContractJsonSerializer_DeserializeMember()
		{
			var serializer = new DataContractJsonSerializer(typeof(ConcreteNoKnownType));
			IAbstract actual = null;

			using (var stream = CreateStream(@"{""Name"":""Test""}"))
			{
				actual = serializer.ReadObject(stream) as IAbstract;
			}

			Assert.IsNotNull(actual, "No object read from stream or cast was not acceptable.");
			Assert.AreEqual("Test", actual.Name);
		}

		[TestMethod]
		public void DataContractJsonSerializer_Serialize()
		{
			// By default this serializer will write type info which is noisy.
			var serializer = new DataContractJsonSerializer(typeof(ConcreteNoKnownType), new List<Type> { typeof(Inner) } );
			IAbstract test = new ConcreteNoKnownType { Name = "Test", Inner = new Inner { Name = "Test" } };
			string actual = null;

			using (var stream = CreateStream(""))
			{
				serializer.WriteObject(stream, test);

				actual = Encoding.ASCII.GetString(stream.GetBuffer(), 0, (int)stream.Length);
			}

			Assert.IsNotNull(actual, "No object written from stream or cast was not acceptable.");
			Assert.AreEqual(@"{""Inner"":{""__type"":""Inner:#WindowClicker.Test"",""Name"":""Test""},""Name"":""Test""}", actual);
		}

		[TestMethod]
		public void DataContractJsonSerializer_SerializeAndDeserialize()
		{
			// By default this serializer will write type info which is noisy.
			var serializer = new DataContractJsonSerializer(typeof(ConcreteNoKnownType), new List<Type> { typeof(Inner) });
			IAbstract test = new ConcreteNoKnownType { Name = "Concrete", Inner = new Inner { Name = "Test" } };
			string json = null;

			using (var stream = CreateStream(""))
			{
				serializer.WriteObject(stream, test);

				json = Encoding.ASCII.GetString(stream.GetBuffer(), 0, (int)stream.Length);
			}

			Assert.IsNotNull(json, "No object written from stream or cast was not acceptable.");
			Assert.AreEqual(@"{""Inner"":{""__type"":""Inner:#WindowClicker.Test"",""Name"":""Test""},""Name"":""Concrete""}", json);

			IAbstract actual = null;

			using (var stream = CreateStream(json))
			{
				actual = serializer.ReadObject(stream) as IAbstract;
			}

			Assert.IsNotNull(actual, "No object read from stream or cast was not acceptable.");
			Assert.AreEqual("Concrete", actual.Name);
			Assert.AreEqual("Test", actual.Inner.Name);
		}

		private MemoryStream CreateStream(string text)
		{
			var stream = new MemoryStream();
			var writer = new StreamWriter(stream);

			writer.Write(text);
			writer.Flush();
			stream.Position = 0;

			return stream;
		}
	}
}
