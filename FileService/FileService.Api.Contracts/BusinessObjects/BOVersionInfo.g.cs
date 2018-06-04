using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Contracts
{
	public partial class BOVersionInfo: AbstractBusinessObject
	{
		public BOVersionInfo() : base()
		{}

		public void SetProperties(long version,
		                          Nullable<DateTime> appliedOn,
		                          string description)
		{
			this.AppliedOn = appliedOn.ToNullableDateTime();
			this.Description = description;
			this.Version = version.ToLong();
		}

		public Nullable<DateTime> AppliedOn { get; private set; }
		public string Description { get; private set; }
		public long Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9415f32b13cdd84c672156b2bea0ae75</Hash>
</Codenesium>*/