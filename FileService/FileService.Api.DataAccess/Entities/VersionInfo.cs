using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
	[Table("VersionInfo", Schema="dbo")]
	public partial class VersionInfo: AbstractEntity
	{
		public VersionInfo()
		{}

		public void SetProperties(
			Nullable<DateTime> appliedOn,
			string description,
			long version)
		{
			this.AppliedOn = appliedOn.ToNullableDateTime();
			this.Description = description;
			this.Version = version.ToLong();
		}

		[Column("AppliedOn", TypeName="datetime")]
		public Nullable<DateTime> AppliedOn { get; private set; }

		[Column("Description", TypeName="nvarchar(1024)")]
		public string Description { get; private set; }

		[Key]
		[Column("Version", TypeName="bigint")]
		public long Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7b60a14f10b20bda177f3b952648c664</Hash>
</Codenesium>*/