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
		public DateTime? AppliedOn { get; private set; }

		[MaxLength(1024)]
		[Column("Description")]
		public string Description { get; private set; }

		[Key]
		[Column("Version")]
		public long Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>828adee5a5899b72c1761de5c31c9e14</Hash>
</Codenesium>*/