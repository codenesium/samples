using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("DatabaseLog", Schema="dbo")]
	public partial class EFDatabaseLog: AbstractEntityFrameworkPOCO
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
    <Hash>bd0c2382f8e072f92c48e51b5b21e5db</Hash>
</Codenesium>*/