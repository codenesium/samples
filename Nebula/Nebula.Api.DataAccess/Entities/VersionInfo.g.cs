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
    <Hash>e5945cc6b987a1455b7c65853a6bd5ba</Hash>
</Codenesium>*/