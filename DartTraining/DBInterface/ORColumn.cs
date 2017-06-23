using System;
using SQLDatabase;

namespace DBInterface
{
	public class ORColumn
	{
		public ORColumn()
		{
			this.AttributeName = "";
			this.ColumnName = "";
			this.ColumnType = ColumnType.VARCHAR;
		}

		public ORColumn(string attributeName, string columnName, string columnType)
		{
			this.AttributeName = attributeName;
			this.ColumnName = columnName;
			ColumnType help;
			Enum.TryParse<ColumnType>(columnType, out help);
			this.ColumnType = help;
		}

		public string AttributeName { get; set; }
		public string ColumnName { get; set; }
		public ColumnType ColumnType { get; set; }
	}
}