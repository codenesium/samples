using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("VersionInfo", Schema="dbo")]
	public partial class VersionInfo : AbstractEntity
	{
		public VersionInfo()
		{
		}

		public virtual void SetProperties(
			long version,
			DateTime? appliedOn,
			string description)
		{
			this.Version = version;
			this.AppliedOn = appliedOn;
			this.Description = description;
		}

		[Column("AppliedOn")]
		public virtual DateTime? AppliedOn { get; private set; }

		[MaxLength(1024)]
		[Column("Description")]
		public virtual string Description { get; private set; }

		[Key]
		[Column("Version")]
		public virtual long Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2a016985cadb1254120577ef988d0bd7</Hash>
</Codenesium>*/