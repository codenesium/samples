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
			this.Database_Version = database_Version;
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
    <Hash>d3fe5376a9cdb0983be11ef0482414d2</Hash>
</Codenesium>*/