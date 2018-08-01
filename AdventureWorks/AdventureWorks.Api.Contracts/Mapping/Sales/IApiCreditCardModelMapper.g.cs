using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiCreditCardModelMapper
	{
		ApiCreditCardResponseModel MapRequestToResponse(
			int creditCardID,
			ApiCreditCardRequestModel request);

		ApiCreditCardRequestModel MapResponseToRequest(
			ApiCreditCardResponseModel response);

		JsonPatchDocument<ApiCreditCardRequestModel> CreatePatch(ApiCreditCardRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d3592c7878727df36aff9b47cb7ed2d4</Hash>
</Codenesium>*/