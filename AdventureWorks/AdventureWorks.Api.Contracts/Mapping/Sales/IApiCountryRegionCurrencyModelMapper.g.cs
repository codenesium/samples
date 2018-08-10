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
    <Hash>feb6566ea39860077573f95869935703</Hash>
</Codenesium>*/