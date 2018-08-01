using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiLinkTypesModelMapper
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
    <Hash>f95b34abcea4fd04b06a5c699f460cd5</Hash>
</Codenesium>*/