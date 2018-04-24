using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("AWBuildVersion", Schema="dbo")]
	public partial class EFAWBuildVersion: AbstractEntityFrameworkPOCO
	{
		public EFAWBuildVersion()
		{}

		public void SetProperties(
			int systemInformationID,
			string database_Version,
			DateTime versionDate,
			DateTime modifiedDate)
		{
			this.SystemInformationID = systemInformationID.ToInt();
			this.Database_Version = database_Version.ToString();
			this.VersionDate = versionDate.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SystemInformationID", TypeName="tinyint")]
		public int SystemInformationID { get; set; }

		[Column("Database Version", TypeName="nvarchar(25)")]
		public string Database_Version { get; set; }

		[Column("VersionDate", TypeName="datetime")]
		public DateTime VersionDate { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>bfec5de5fdb88edcca542e15522a9807</Hash>
</Codenesium>*/