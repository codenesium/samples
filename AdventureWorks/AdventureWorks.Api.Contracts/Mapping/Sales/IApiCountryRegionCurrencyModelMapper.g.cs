using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiCountryRegionCurrencyModelMapper
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
    <Hash>5fd03f3996680b72f43333b7b761d0f2</Hash>
</Codenesium>*/