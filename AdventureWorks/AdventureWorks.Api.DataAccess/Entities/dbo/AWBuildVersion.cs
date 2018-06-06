using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("AWBuildVersion", Schema="dbo")]
	public partial class AWBuildVersion: AbstractEntity
	{
		public AWBuildVersion()
		{}

		public void SetProperties(
			string database_Version,
			DateTime modifiedDate,
			int systemInformationID,
			DateTime versionDate)
		{
			this.Database_Version = database_Version;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.SystemInformationID = systemInformationID.ToInt();
			this.VersionDate = versionDate.ToDateTime();
		}

		[Column("Database Version", TypeName="nvarchar(25)")]
		public string Database_Version { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("SystemInformationID", TypeName="tinyint")]
		public int SystemInformationID { get; private set; }

		[Column("VersionDate", TypeName="datetime")]
		public DateTime VersionDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>96468b2d9803267c998a5a8ff00bddd1</Hash>
</Codenesium>*/