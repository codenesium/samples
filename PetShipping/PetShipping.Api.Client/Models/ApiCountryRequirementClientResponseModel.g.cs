using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiCountryRequirementClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int countryId,
			string details)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Details = details;

			this.CountryIdEntity = nameof(ApiResponse.Countries);
		}

		[JsonProperty]
		public ApiCountryClientResponseModel CountryIdNavigation { get; private set; }

		public void SetCountryIdNavigation(ApiCountryClientResponseModel value)
		{
			this.CountryIdNavigation = value;
		}

		[JsonProperty]
		public int CountryId { get; private set; }

		[JsonProperty]
		public string CountryIdEntity { get; set; }

		[JsonProperty]
		public string Details { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ef490ca14530b534cfb4bf4daabd57be</Hash>
</Codenesium>*/