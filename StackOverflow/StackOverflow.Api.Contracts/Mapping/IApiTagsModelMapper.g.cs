using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiTagsModelMapper
	{
		ApiTagsResponseModel MapRequestToResponse(
			int id,
			ApiTagsRequestModel request);

		ApiTagsRequestModel MapResponseToRequest(
			ApiTagsResponseModel response);

		JsonPatchDocument<ApiTagsRequestModel> CreatePatch(ApiTagsRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a5b879adb46cd4f0bd475738d5255f05</Hash>
</Codenesium>*/