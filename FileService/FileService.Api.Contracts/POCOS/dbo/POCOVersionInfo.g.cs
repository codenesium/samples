using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FileServiceNS.Api.Contracts
{
	public partial class POCOVersionInfo
	{
		public POCOVersionInfo()
		{}

		public POCOVersionInfo(
			Nullable<DateTime> appliedOn,
			string description,
			long version)
		{
			this.AppliedOn = appliedOn.ToNullableDateTime();
			this.Description = description;
			this.Version = version.ToLong();
		}

		public Nullable<DateTime> AppliedOn { get; set; }
		public string Description { get; set; }
		public long Version { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAppliedOnValue { get; set; } = true;

		public bool ShouldSerializeAppliedOn()
		{
			return this.ShouldSerializeAppliedOnValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue { get; set; } = true;

		public bool ShouldSerializeDescription()
		{
			return this.ShouldSerializeDescriptionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeVersionValue { get; set; } = true;

		public bool ShouldSerializeVersion()
		{
			return this.ShouldSerializeVersionValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAppliedOnValue = false;
			this.ShouldSerializeDescriptionValue = false;
			this.ShouldSerializeVersionValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>245f237ef03269ef333c48cec387b66c</Hash>
</Codenesium>*/