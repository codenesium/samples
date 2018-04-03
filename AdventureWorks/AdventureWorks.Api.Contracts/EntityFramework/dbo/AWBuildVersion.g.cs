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
		public int systemInformationID {get; set;}
		public string database_Version {get; set;}
		public DateTime versionDate {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>7877688c0432608325e27cf8b7be6053</Hash>
</Codenesium>*/