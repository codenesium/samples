using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("DatabaseLog", Schema="dbo")]
	public partial class DatabaseLog: AbstractEntityFrameworkPOCO
	{
		public DatabaseLog()
		{}

		public void SetProperties(
			int databaseLogID,
			string databaseUser,
			string @event,
			string @object,
			DateTime postTime,
			string schema,
			string tSQL,
			string xmlEvent)
		{
			this.DatabaseLogID = databaseLogID.ToInt();
			this.DatabaseUser = databaseUser.ToString();
			this.@Event = @event.ToString();
			this.@Object = @object.ToString();
			this.PostTime = postTime.ToDateTime();
			this.Schema = schema.ToString();
			this.TSQL = tSQL.ToString();
			this.XmlEvent = xmlEvent;
		}

		[Key]
		[Column("DatabaseLogID", TypeName="int")]
		public int DatabaseLogID { get; set; }

		[Column("DatabaseUser", TypeName="nvarchar(128)")]
		public string DatabaseUser { get; set; }

		[Column("Event", TypeName="nvarchar(128)")]
		public string @Event { get; set; }

		[Column("Object", TypeName="nvarchar(128)")]
		public string @Object { get; set; }

		[Column("PostTime", TypeName="datetime")]
		public DateTime PostTime { get; set; }

		[Column("Schema", TypeName="nvarchar(128)")]
		public string Schema { get; set; }

		[Column("TSQL", TypeName="nvarchar(-1)")]
		public string TSQL { get; set; }

		[Column("XmlEvent", TypeName="xml(-1)")]
		public string XmlEvent { get; set; }
	}
}

/*<Codenesium>
    <Hash>98c6224249734f240d4a93bc1df153cd</Hash>
</Codenesium>*/