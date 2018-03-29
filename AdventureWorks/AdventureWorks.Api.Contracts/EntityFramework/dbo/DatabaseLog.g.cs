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
		public int DatabaseLogID {get; set;}
		public DateTime PostTime {get; set;}
		public string DatabaseUser {get; set;}
		public string @Event {get; set;}
		public string Schema {get; set;}
		public string @Object {get; set;}
		public string TSQL {get; set;}
		public string XmlEvent {get; set;}
	}
}

/*<Codenesium>
    <Hash>4462e731bdd7dc0d97c970ef30942093</Hash>
</Codenesium>*/