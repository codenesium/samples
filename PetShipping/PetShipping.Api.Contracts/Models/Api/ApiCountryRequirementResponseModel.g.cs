using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiCountryRequirementResponseModel: AbstractApiResponseModel
	{
		public ApiCountryRequirementResponseModel() : base()
		{}

		public void SetProperties(
			int countryId,
			string details,
			int id)
		{
			this.CountryId = countryId.ToInt();
			this.Details = details;
			this.Id = id.ToInt();

			this.CountryIdEntity = nameof(ApiResponse.Countries);
		}

		public int CountryId { get; private set; }
		public string CountryIdEntity { get; set; }
		public string Details { get; private set; }
		public int Id { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeCountryIdValue { get; set; } = true;

		public bool ShouldSerializeCountryId()
		{
			return this.ShouldSerializeCountryIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDetailsValue { get; set; } = true;

		public bool ShouldSerializeDetails()
		{
			return this.ShouldSerializeDetailsValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCountryIdValue = false;
			this.ShouldSerializeDetailsValue = false;
			this.ShouldSerializeIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>3804626a39d6cd5ff8f27a1f0b2e1ba8</Hash>
</Codenesium>*/