using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("AWBuildVersion", Schema="dbo")]
	public partial class AWBuildVersion : AbstractEntity
	{
		public AWBuildVersion()
		{
		}

		public virtual void SetProperties(
			int systemInformationID,
			string database_Version,
			DateTime modifiedDate,
			DateTime versionDate)
		{
			this.SystemInformationID = systemInformationID;
			this.Database_Version = database_Version;
			this.ModifiedDate = modifiedDate;
			this.VersionDate = versionDate;
		}

		[MaxLength(25)]
		[Column("Database Version")]
		public virtual string Database_Version { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("SystemInformationID")]
		public virtual int SystemInformationID { get; private set; }

		[Column("VersionDate")]
		public virtual DateTime VersionDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>19820ae72c6df19ad593adb62b0ecb9f</Hash>
</Codenesium>*/