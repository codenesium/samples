using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Contracts
{
	public partial class DTOVersionInfo: AbstractDTO
	{
		public DTOVersionInfo() : base()
		{}

		public void SetProperties(long version,
		                          Nullable<DateTime> appliedOn,
		                          string description)
		{
			this.AppliedOn = appliedOn.ToNullableDateTime();
			this.Description = description;
			this.Version = version.ToLong();
		}

		public Nullable<DateTime> AppliedOn { get; set; }
		public string Description { get; set; }
		public long Version { get; set; }
	}
}

/*<Codenesium>
    <Hash>ce791422b3fe218d80102b8bd014683c</Hash>
</Codenesium>*/