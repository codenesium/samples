using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiCountryRegionCurrencyModelMapper
	{
		ApiCountryRegionCurrencyResponseModel MapRequestToResponse(
			string countryRegionCode,
			ApiCountryRegionCurrencyRequestModel request);

		ApiCountryRegionCurrencyRequestModel MapResponseToRequest(
			ApiCountryRegionCurrencyResponseModel response);

		JsonPatchDocument<ApiCountryRegionCurrencyRequestModel> CreatePatch(ApiCountryRegionCurrencyRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2500ec5e0fb4c1f9586741cbd7a1bdff</Hash>
</Codenesium>*/