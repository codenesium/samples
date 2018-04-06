using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("AWBuildVersion", Schema="dbo")]
	public partial class EFAWBuildVersion
	{
		public EFAWBuildVersion()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SystemInformationID", TypeName="tinyint")]
		public int SystemInformationID {get; set;}
		[Column("Database Version", TypeName="nvarchar(25)")]
		public string Database_Version {get; set;}
		[Column("VersionDate", TypeName="datetime")]
		public DateTime VersionDate {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>84c8fe7b71d7123f3db14cea89e06578</Hash>
</Codenesium>*/