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
			string detail)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Detail = detail;

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
		public string Detail { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>26780c4d648916b7635531ae7b2a3bdb</Hash>
</Codenesium>*/