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
    <Hash>434f1b85ca0c9cca53471e3086652619</Hash>
</Codenesium>*/