using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
	[Table("VersionInfo", Schema="dbo")]
	public partial class VersionInfo: AbstractEntityFrameworkPOCO
	{
		public VersionInfo()
		{}

		public void SetProperties(
			long version,
			Nullable<DateTime> appliedOn,
			string description)
		{
			this.AppliedOn = appliedOn.ToNullableDateTime();
			this.Description = description;
			this.Version = version.ToLong();
		}

		[Column("AppliedOn", TypeName="datetime")]
		public Nullable<DateTime> AppliedOn { get; set; }

		[Column("Description", TypeName="nvarchar(1024)")]
		public string Description { get; set; }

		[Key]
		[Column("Version", TypeName="bigint")]
		public long Version { get; set; }
	}
}

/*<Codenesium>
    <Hash>332bf65210f50ef686389554a9ba7c27</Hash>
</Codenesium>*/