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
    <Hash>9b4abe18964678f5684a57386ad30c7c</Hash>
</Codenesium>*/