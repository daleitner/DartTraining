using System;
using System.Collections.Generic;
using System.Linq;
using Base;
using FileIO.XMLReader;
using SQLDatabase;

namespace DBInterface
{
	public class ORDictionary
	{
		public ORDictionary(string orMappingFilePath)
		{
			this.OREntries = LoadORMappingFile(orMappingFilePath);
		}

		public List<OREntry> OREntries { get; set; }

		private static List<OREntry> LoadORMappingFile(string orMappingFilePath)
		{
			var ret = new List<OREntry>();
			if (!System.IO.File.Exists(orMappingFilePath))
				return ret;

			var xml = XMLReader.ReadXMLFile(orMappingFilePath);
			if (xml == null)
				return ret;

			var mappingsNode = xml.FirstOrDefault();
			if (mappingsNode?.Childs == null)
				return ret;

			foreach (var n in mappingsNode.Childs)
			{
				if (n.Name != "Table")
					continue;

				var table = n.Attributes["name"];
				var csObject = n.Attributes["csobject"];
				var columns = new List<ORColumn>();
				if (n.Childs != null)
				{
					foreach (var c in n.Childs)
					{
						if (c.Name != "Column")
							continue;

						var attribute = "";
						if(c.Attributes.Keys.Contains("attribute"))
							attribute = c.Attributes["attribute"];
						var column = c.Attributes["name"];
						var type = c.Attributes["type"];
						columns.Add(new ORColumn(attribute, column, type));
					}
				}
				ret.Add(new OREntry(csObject, table, columns));
			}
			return ret;
		}
		
		public OREntry GetEntryByTable(string tableName)
		{
			return this.OREntries.FirstOrDefault(x => x.RelationName == tableName);
		}

		public OREntry GetEntryByObject(string csObjectName)
		{
			return this.OREntries.FirstOrDefault(x => x.ObjectName == csObjectName);
		}

		public DataBaseTable GetTableByObject(Type t)
		{
			var entry = this.OREntries.FirstOrDefault(x => x.ObjectName == t.Name);
			return new DataBaseTable(entry.RelationName, entry.Columns.Select(x => new DataBaseColumn(x.ColumnName, x.ColumnType)).ToList());
		}

		public DataBaseTable GetTableByRelation(string relationName)
		{ 
			var entry = this.OREntries.FirstOrDefault(x => x.RelationName == relationName);
			return new DataBaseTable(entry.RelationName, entry.Columns.Select(x => new DataBaseColumn(x.ColumnName, x.ColumnType)).ToList());
		}

		public Dictionary<DataBaseColumn, object> CreateDatabaseDictionary(DataBaseTable table, ModelBase model)
		{
			return CreateDatabaseDictionary(table, model, null);
		}

		public Dictionary<DataBaseColumn, object> CreateDatabaseDictionary(DataBaseTable table, ModelBase model, ModelBase parentModel)
		{
			var ret = new Dictionary<DataBaseColumn, object>();
			var entry = this.OREntries.FirstOrDefault(x => x.RelationName == table.Name);
			foreach (var col in entry.Columns)
			{
				var column = table.Columns[col.ColumnName];
				object objectValue = null;
				if (col.AttributeName == "Id")
					objectValue = model.Id;
				else if (col.AttributeName == "ParentId")
					objectValue = parentModel.Id;
				else
				{
					if (column.Type == ColumnType.VARCHAR && model.GetType().GetProperty(col.AttributeName).PropertyType != typeof(string))
					{
						if (model.GetType().GetProperty(col.AttributeName).PropertyType.IsEnum)
							objectValue = model.GetType().GetProperty(col.AttributeName).GetValue(model);
						else
						{
							var help = model.GetType().GetProperty(col.AttributeName).GetValue(model) as ModelBase;
							if (help != null)
								objectValue = help.Id;
							else
								throw new NotSupportedException("Attribut <" + col.AttributeName + "> ist kein gültiger Datentyp!");
						}
					}
					else
					{
						objectValue = model.GetType().GetProperty(col.AttributeName).GetValue(model);
					}
				}
				ret.Add(column, objectValue);
			}
			return ret;
		}
 }
}