using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCurrencyServerModelMapper
	{
		ApiCurrencyServerResponseModel MapServerRequestToResponse(
			string currencyCode,
			ApiCurrencyServerRequestModel request);

		ApiCurrencyServerRequestModel MapServerResponseToRequest(
			ApiCurrencyServerResponseModel response);

		ApiCurrencyClientRequestModel MapServerResponseToClientRequest(
			ApiCurrencyServerResponseModel response);

		JsonPatchDocument<ApiCurrencyServerRequestModel> CreatePatch(ApiCurrencyServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0588e73dc903556bf49e80e2581cca7c</Hash>
</Codenesium>*/