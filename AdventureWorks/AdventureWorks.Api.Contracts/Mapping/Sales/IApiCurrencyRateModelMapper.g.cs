using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiCurrencyRateModelMapper
	{
		ApiCurrencyRateResponseModel MapRequestToResponse(
			int currencyRateID,
			ApiCurrencyRateRequestModel request);

		ApiCurrencyRateRequestModel MapResponseToRequest(
			ApiCurrencyRateResponseModel response);

		JsonPatchDocument<ApiCurrencyRateRequestModel> CreatePatch(ApiCurrencyRateRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2edc729118f20e87fe07b0108b71a202</Hash>
</Codenesium>*/