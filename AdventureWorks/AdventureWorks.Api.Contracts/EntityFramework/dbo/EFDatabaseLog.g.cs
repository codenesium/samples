using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("DatabaseLog", Schema="dbo")]
	public partial class EFDatabaseLog
	{
		public EFDatabaseLog()
		{}

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
    <Hash>eefbfc34b82a00ace09aebd47137a428</Hash>
</Codenesium>*/