using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("DatabaseLog", Schema="dbo")]
	public partial class DatabaseLog: AbstractEntity
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
			this.DatabaseUser = databaseUser;
			this.@Event = @event;
			this.@Object = @object;
			this.PostTime = postTime.ToDateTime();
			this.Schema = schema;
			this.TSQL = tSQL;
			this.XmlEvent = xmlEvent;
		}

		[Key]
		[Column("DatabaseLogID", TypeName="int")]
		public int DatabaseLogID { get; private set; }

		[Column("DatabaseUser", TypeName="nvarchar(128)")]
		public string DatabaseUser { get; private set; }

		[Column("Event", TypeName="nvarchar(128)")]
		public string @Event { get; private set; }

		[Column("Object", TypeName="nvarchar(128)")]
		public string @Object { get; private set; }

		[Column("PostTime", TypeName="datetime")]
		public DateTime PostTime { get; private set; }

		[Column("Schema", TypeName="nvarchar(128)")]
		public string Schema { get; private set; }

		[Column("TSQL", TypeName="nvarchar(-1)")]
		public string TSQL { get; private set; }

		[Column("XmlEvent", TypeName="xml(-1)")]
		public string XmlEvent { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cacd1ca435ba52146a4e71964d7b19b8</Hash>
</Codenesium>*/