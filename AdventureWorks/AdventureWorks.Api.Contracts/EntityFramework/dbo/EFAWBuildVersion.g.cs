using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("AWBuildVersion", Schema="dbo")]
	public partial class EFAWBuildVersion
	{
		public EFAWBuildVersion()
		{}

		public void SetProperties(int systemInformationID,
		                          string database_Version,
		                          DateTime versionDate,
		                          DateTime modifiedDate)
		{
			this.SystemInformationID = systemInformationID;
			this.Database_Version = database_Version;
			this.VersionDate = versionDate.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

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
    <Hash>44ca8be8f5616cf27b11f2bd06674b7b</Hash>
</Codenesium>*/