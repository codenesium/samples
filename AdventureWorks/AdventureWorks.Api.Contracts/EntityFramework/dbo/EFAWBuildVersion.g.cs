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
    <Hash>4e97e603af11f1c2b573fc90c31b8700</Hash>
</Codenesium>*/