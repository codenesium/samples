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
		public int databaseLogID {get; set;}
		public DateTime postTime {get; set;}
		public string databaseUser {get; set;}
		public string @event {get; set;}
		public string schema {get; set;}
		public string @object {get; set;}
		public string tSQL {get; set;}
		public string xmlEvent {get; set;}
	}
}

/*<Codenesium>
    <Hash>34fb2362259a569973d895c0d1750fa6</Hash>
</Codenesium>*/