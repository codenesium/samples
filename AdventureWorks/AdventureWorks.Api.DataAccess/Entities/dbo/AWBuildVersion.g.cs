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
			string database_Version,
			DateTime modifiedDate,
			int systemInformationID,
			DateTime versionDate)
		{
			this.Database_Version = database_Version;
			this.ModifiedDate = modifiedDate;
			this.SystemInformationID = systemInformationID;
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
    <Hash>860d7c2393935b7d4f94bbc6f83f9c4c</Hash>
</Codenesium>*/