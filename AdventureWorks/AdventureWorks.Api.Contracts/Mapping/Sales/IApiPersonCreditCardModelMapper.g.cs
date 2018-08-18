using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiPersonCreditCardModelMapper
	{
		ApiPersonCreditCardResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPersonCreditCardRequestModel request);

		ApiPersonCreditCardRequestModel MapResponseToRequest(
			ApiPersonCreditCardResponseModel response);

		JsonPatchDocument<ApiPersonCreditCardRequestModel> CreatePatch(ApiPersonCreditCardRequestModel model);
	}
}

/*<Codenesium>
    <Hash>51ae56cd6ce69182c7041ea9629fc4a6</Hash>
</Codenesium>*/