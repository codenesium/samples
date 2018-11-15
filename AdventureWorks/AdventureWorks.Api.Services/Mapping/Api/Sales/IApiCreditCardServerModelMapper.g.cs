using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCreditCardServerModelMapper
	{
		ApiCreditCardServerResponseModel MapServerRequestToResponse(
			int creditCardID,
			ApiCreditCardServerRequestModel request);

		ApiCreditCardServerRequestModel MapServerResponseToRequest(
			ApiCreditCardServerResponseModel response);

		ApiCreditCardClientRequestModel MapServerResponseToClientRequest(
			ApiCreditCardServerResponseModel response);

		JsonPatchDocument<ApiCreditCardServerRequestModel> CreatePatch(ApiCreditCardServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>01310ee0f3616316b1423581c190e68b</Hash>
</Codenesium>*/