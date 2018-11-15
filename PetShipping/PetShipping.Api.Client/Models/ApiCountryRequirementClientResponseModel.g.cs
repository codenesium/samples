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
    <Hash>d640ff3a6999bf41b4ee0f30e5d92c1f</Hash>
</Codenesium>*/