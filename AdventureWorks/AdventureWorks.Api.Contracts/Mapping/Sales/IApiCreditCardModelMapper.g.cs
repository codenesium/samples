using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiCreditCardModelMapper
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
    <Hash>01bf44ef8f09f26b1f6618f973291ebb</Hash>
</Codenesium>*/