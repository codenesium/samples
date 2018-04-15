using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("DatabaseLog", Schema="dbo")]
	public partial class EFDatabaseLog
	{
		public EFDatabaseLog()
		{}

		public void SetProperties(
			int databaseLogID,
			DateTime postTime,
			string databaseUser,
			string @event,
			string schema,
			string @object,
			string tSQL,
			string xmlEvent)
		{
			this.DatabaseLogID = databaseLogID.ToInt();
			this.PostTime = postTime.ToDateTime();
			this.DatabaseUser = databaseUser.ToString();
			this.@Event = @event.ToString();
			this.Schema = schema.ToString();
			this.@Object = @object.ToString();
			this.TSQL = tSQL.ToString();
			this.XmlEvent = xmlEvent;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("DatabaseLogID", TypeName="int")]
		public int DatabaseLogID { get; set; }

		[Column("PostTime", TypeName="datetime")]
		public DateTime PostTime { get; set; }

		[Column("DatabaseUser", TypeName="nvarchar(128)")]
		public string DatabaseUser { get; set; }

		[Column("Event", TypeName="nvarchar(128)")]
		public string @Event { get; set; }

		[Column("Schema", TypeName="nvarchar(128)")]
		public string Schema { get; set; }

		[Column("Object", TypeName="nvarchar(128)")]
		public string @Object { get; set; }

		[Column("TSQL", TypeName="nvarchar(-1)")]
		public string TSQL { get; set; }

		[Column("XmlEvent", TypeName="xml(-1)")]
		public string XmlEvent { get; set; }
	}
}

/*<Codenesium>
    <Hash>125a6cc66c6a040322e08801ccbb5a6d</Hash>
</Codenesium>*/