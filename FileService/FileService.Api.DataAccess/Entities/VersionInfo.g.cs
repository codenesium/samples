using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FileServiceNS.Api.DataAccess
{
	[Table("VersionInfo", Schema="dbo")]
	public partial class VersionInfo : AbstractEntity
	{
		public VersionInfo()
		{
		}

		public virtual void SetProperties(
			DateTime? appliedOn,
			string description,
			long version)
		{
			this.AppliedOn = appliedOn;
			this.Description = description;
			this.Version = version;
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
    <Hash>7c354c201578579b7623f7deb02bd6f0</Hash>
</Codenesium>*/