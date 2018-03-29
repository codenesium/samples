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
		public int SystemInformationID {get; set;}
		public string Database_Version {get; set;}
		public DateTime VersionDate {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>e96574258c870e61a8655cffa5fd305d</Hash>
</Codenesium>*/