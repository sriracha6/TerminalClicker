using System;
using System.Reflection;
using System.Xml;

namespace TerminalClicker
{
	public static class SaveProgress
	{
		public static void Save()
		{
			List<(string name, string value)> vals = new List<(string name, string value)>();
			foreach(Type t in Assembly.GetExecutingAssembly().GetTypes().Where(t=>t.Namespace.StartsWith("TerminalClicker")))
			{
				foreach(FieldInfo fi in t.GetFields(BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.NonPublic))
				{
					if(fi.GetCustomAttributes().ToList().Exists(x=>x.GetType() == typeof(InSave)))
						vals.Add((fi.Name,fi.GetValue(t).ToString()));
				}
			}
			XmlWriter xmlWriter = XmlWriter.Create("save");
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteComment(" BOO! ");
			xmlWriter.WriteStartElement("Save");
            foreach (var v in vals)
			{
				xmlWriter.WriteStartElement(v.name);
				xmlWriter.WriteValue(v.value);
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();
			xmlWriter.Close();
		}
	}

	public class InSave : Attribute
	{
		public InSave()
		{

		}
	}
}
