using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
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
    <Hash>33efa77ff80b9320dfc8d7c5ee69592b</Hash>
</Codenesium>*/