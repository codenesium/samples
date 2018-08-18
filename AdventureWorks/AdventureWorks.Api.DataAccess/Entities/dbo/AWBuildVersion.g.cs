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
		public string Database_Version { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SystemInformationID")]
		public int SystemInformationID { get; private set; }

		[Column("VersionDate")]
		public DateTime VersionDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2084aeec7553c1e6037dea71e3a3dcae</Hash>
</Codenesium>*/