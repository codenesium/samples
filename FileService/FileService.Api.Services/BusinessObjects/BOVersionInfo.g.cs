using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Services
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
    <Hash>c0968d18e1cd1ba198d5c5b0e5c86c5a</Hash>
</Codenesium>*/