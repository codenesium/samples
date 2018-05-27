using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
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
    <Hash>d4b7fd581009589e16c1f6b0663701e1</Hash>
</Codenesium>*/