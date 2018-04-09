using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("DatabaseLog", Schema="dbo")]
	public partial class EFDatabaseLog
	{
		public EFDatabaseLog()
		{}

		public void SetProperties(int databaseLogID,
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
			this.DatabaseUser = databaseUser;
			this.@Event = @event;
			this.Schema = schema;
			this.@Object = @object;
			this.TSQL = tSQL;
			this.XmlEvent = xmlEvent;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("DatabaseLogID", TypeName="int")]
		public int DatabaseLogID {get; set;}

		[Column("PostTime", TypeName="datetime")]
		public DateTime PostTime {get; set;}

		[Column("DatabaseUser", TypeName="nvarchar(128)")]
		public string DatabaseUser {get; set;}

		[Column("Event", TypeName="nvarchar(128)")]
		public string @Event {get; set;}

		[Column("Schema", TypeName="nvarchar(128)")]
		public string Schema {get; set;}

		[Column("Object", TypeName="nvarchar(128)")]
		public string @Object {get; set;}

		[Column("TSQL", TypeName="nvarchar(-1)")]
		public string TSQL {get; set;}

		[Column("XmlEvent", TypeName="xml(-1)")]
		public string XmlEvent {get; set;}
	}
}

/*<Codenesium>
    <Hash>a4f276c71ba66e7a18bc477374942905</Hash>
</Codenesium>*/