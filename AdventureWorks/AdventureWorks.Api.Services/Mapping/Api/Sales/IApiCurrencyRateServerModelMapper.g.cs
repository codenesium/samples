using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCurrencyRateServerModelMapper
	{
		ApiCurrencyRateServerResponseModel MapServerRequestToResponse(
			int currencyRateID,
			ApiCurrencyRateServerRequestModel request);

		ApiCurrencyRateServerRequestModel MapServerResponseToRequest(
			ApiCurrencyRateServerResponseModel response);

		ApiCurrencyRateClientRequestModel MapServerResponseToClientRequest(
			ApiCurrencyRateServerResponseModel response);

		JsonPatchDocument<ApiCurrencyRateServerRequestModel> CreatePatch(ApiCurrencyRateServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4fef1e92cf193c47681d0df612c3b128</Hash>
</Codenesium>*/