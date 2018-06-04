using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApiVersionInfoResponseModel: AbstractApiResponseModel
	{
		public ApiVersionInfoResponseModel() : base()
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

		public Nullable<DateTime> AppliedOn { get; private set; }
		public string Description { get; private set; }
		public long Version { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeAppliedOnValue { get; set; } = false;

		public bool ShouldSerializeAppliedOn()
		{
			return this.ShouldSerializeAppliedOnValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue { get; set; } = false;

		public bool ShouldSerializeDescription()
		{
			return this.ShouldSerializeDescriptionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeVersionValue { get; set; } = false;

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
    <Hash>75d85ea7f84ddaa8ccc2f295eca1c962</Hash>
</Codenesium>*/