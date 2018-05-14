using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("AWBuildVersion", Schema="dbo")]
	public partial class AWBuildVersion: AbstractEntityFrameworkPOCO
	{
		public AWBuildVersion()
		{}

		public void SetProperties(
			int systemInformationID,
			string database_Version,
			DateTime modifiedDate,
			DateTime versionDate)
		{
			this.Database_Version = database_Version.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.SystemInformationID = systemInformationID.ToInt();
			this.VersionDate = versionDate.ToDateTime();
		}

		[Column("Database Version", TypeName="nvarchar(25)")]
		public string Database_Version { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Key]
		[Column("SystemInformationID", TypeName="tinyint")]
		public int SystemInformationID { get; set; }

		[Column("VersionDate", TypeName="datetime")]
		public DateTime VersionDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>ed329147fad3d34d34810f6717527e49</Hash>
</Codenesium>*/