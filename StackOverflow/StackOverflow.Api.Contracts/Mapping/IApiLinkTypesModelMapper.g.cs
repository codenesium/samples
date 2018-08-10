using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiLinkTypesModelMapper
	{
		ApiLinkTypesResponseModel MapRequestToResponse(
			int id,
			ApiLinkTypesRequestModel request);

		ApiLinkTypesRequestModel MapResponseToRequest(
			ApiLinkTypesResponseModel response);

		JsonPatchDocument<ApiLinkTypesRequestModel> CreatePatch(ApiLinkTypesRequestModel model);
	}
}

/*<Codenesium>
    <Hash>24b00b78e8a4af54f02a4bc25c88372a</Hash>
</Codenesium>*/