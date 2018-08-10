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
    <Hash>e7fd5cacfbf684fb464090b369d1b6ea</Hash>
</Codenesium>*/