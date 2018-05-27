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
    <Hash>6870c0ae34f16955cd2b2af03c6f4b3c</Hash>
</Codenesium>*/