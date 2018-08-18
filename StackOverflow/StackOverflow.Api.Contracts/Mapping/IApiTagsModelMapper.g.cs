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
    <Hash>b3d5c7f7011138a0d024263c9cca8d4f</Hash>
</Codenesium>*/