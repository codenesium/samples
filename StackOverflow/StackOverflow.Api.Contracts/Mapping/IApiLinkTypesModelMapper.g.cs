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
    <Hash>27220edabcb9b4ce2333cdd22ddbc6c6</Hash>
</Codenesium>*/