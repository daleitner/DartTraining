using System.Collections.Generic;

namespace DBInterface
{
	public class OREntry
	{
		public OREntry()
		{
			this.RelationName = "";
			this.Columns = null;
			this.ObjectName = null;
		}

		public OREntry(string objectName, string relationName, List<ORColumn> columns)
		{
			this.RelationName = relationName;
			this.Columns = columns;
			this.ObjectName = objectName;
		}

		public string RelationName { get; set; }
		public List<ORColumn> Columns { get; set; }
		public string ObjectName { get; set; }
	}
}