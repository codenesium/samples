using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiCurrencyRateModelMapper
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
    <Hash>34eeff4e23351f1585cf2a75440c1d0b</Hash>
</Codenesium>*/