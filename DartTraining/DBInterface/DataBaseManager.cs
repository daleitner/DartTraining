using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Base;
using FileIO.FileReader;
using FileIO.XMLReader;
using SQLDatabase;

namespace DBInterface
{
	public class DataBaseManager
	{
		#region members
		private static DataBaseManager dbi;
		private readonly string setup = Directory.GetCurrentDirectory() + "\\database.xml";
		private readonly string testValueFile = Directory.GetCurrentDirectory() + "\\initialValues.txt";
		private readonly string mappingPath = Directory.GetCurrentDirectory() + "\\mapping.xml";
		private string databaseName = "";
		#endregion

		#region ctor
		private DataBaseManager()
		{
			Initialize();
		}

		private void Initialize()
		{
			var dbconfig = ReadSetup();
			var testValueCommands = ReadTestValues();
			if (dbconfig != null)
				this.DataBaseConnection = new DataBaseConnection(dbconfig.Keys.First(), dbconfig.Values.First(), testValueCommands);
			this.Mapping = new ORDictionary(this.mappingPath);
		}

		public static DataBaseManager GetInstance()
		{
			return dbi ?? (dbi = new DataBaseManager());
		}
		#endregion

		#region properties
		private DataBaseConnection DataBaseConnection { get; set; }
		private ORDictionary Mapping { get; set; }
		#endregion

		#region private methods
		private Dictionary<string, List<DataBaseTable>> ReadSetup()
		{
			if (!File.Exists(this.setup))
				return null;

			var ret = new Dictionary<string, List<DataBaseTable>>();
			var dbTables = new List<DataBaseTable>();
			var xml = XMLReader.ReadXMLFile(this.setup);

			Node dataBaseNode = null;
			if(xml != null)
				dataBaseNode = xml.FirstOrDefault();
			if (dataBaseNode == null)
				return null;
			this.databaseName = dataBaseNode.Attributes["name"];
			var dataBase = dataBaseNode.Attributes[dataBaseNode.Attributes.Keys.First()];
			List<Node> tables = null;
			if (dataBaseNode.Childs != null)
			{
				foreach (var n in dataBaseNode.Childs.Where(n => n.Name == "Tables"))
				{
					tables = n.Childs;
					break;
				}
			}

			if (tables == null)
				return null;

			dbTables.AddRange(tables.Select(NodeToDataBaseTable));
			ret.Add(dataBase, dbTables);
			return ret;
		}


		private List<string> ReadTestValues()
		{
			if (!File.Exists(this.testValueFile))
				return null;

			var f = FileReader.ReadFile(this.testValueFile);
			var lines = f.Replace("\r", "").Split('\n');
			return lines.Where(t => !string.IsNullOrEmpty(t)).ToList();
		}

		private static DataBaseTable NodeToDataBaseTable(Node node)
		{
			if (node == null || node.Name != "Table")
				return null;

			var columns = new List<DataBaseColumn>();
			var fcolumns = new List<ForeignKeyColumn>();
			if (node.Childs == null)
				return new DataBaseTable(node.Attributes["name"], columns, fcolumns);
			foreach (var n in node.Childs)
			{
				if (n.Name != "Column")
					continue;

				var columnName = n.Attributes["name"];
				ColumnType columnType;
				Enum.TryParse(n.Attributes["type"], out columnType);
				if (n.Attributes.Keys.Contains("foreignkey"))
				{
					var foreignkey = n.Attributes["foreignkey"];
					var referenceTable = n.Attributes["reference"];
					fcolumns.Add(new ForeignKeyColumn(columnName, columnType, referenceTable, foreignkey));
				}
				else
				{
					var isPrimaryKey = false;
					if (n.Attributes.Keys.Contains("primarykey"))
						bool.TryParse(n.Attributes["primarykey"], out isPrimaryKey);
					columns.Add(new DataBaseColumn(columnName, columnType, isPrimaryKey));
				}
			}
			return new DataBaseTable(node.Attributes["name"], columns, fcolumns);
		}
		#endregion

		#region public methods

		public List<T> GetAll<T>() where T : ModelBase
		{
			var query = new DataBaseQuery(this.Mapping.GetTableByObject(typeof(T)));
			return this.DataBaseConnection.ExecuteQuery(query).Select(x => (T)Activator.CreateInstance(typeof(T), x)).ToList();
		}

		public T Get<T>(string id) where T : ModelBase
		{
			var table = this.Mapping.GetTableByObject(typeof (T));
			var entry = this.Mapping.GetEntryByTable(table.Name);
			var columnEntry = entry.Columns.FirstOrDefault(x => x.AttributeName == "Id");
			var query = new DataBaseQuery(table, new Condition().Add(new PropertyExpression(table.Columns[columnEntry.ColumnName], CompareEnum.Equals, id)));
			return this.DataBaseConnection.ExecuteQuery(query).Select(x => (T)Activator.CreateInstance(typeof(T), x)).FirstOrDefault();
		}

		//public void Insert(ModelBase newModel)
		//{
		//	Insert(newModel, null);
		//}

		//public void Insert(ModelBase newModel, ModelBase parentModel)
		//{
		//	var table = this.Mapping.GetTableByObject(newModel.GetType());
		//	var dictionary = this.Mapping.CreateDatabaseDictionary(table, newModel, parentModel);
		//	this.DataBaseConnection.InsertElement(new SQLDatabase.ElementInsert(table, dictionary));
		//}

		//public void Insert(ModelBaseTree newModelTree, ModelBase parentModel)
		//{
		//	Insert(newModelTree.Model, parentModel);
		//	foreach (var modelList in newModelTree.Children)
		//	{
		//		foreach (var child in modelList)
		//		{
		//			Insert(child, newModelTree.Model);
		//		}
		//	}
		//}

		//public string GetDatabaseName()
		//{
		//	return this.databaseName;
		//}
		#endregion
	}
}