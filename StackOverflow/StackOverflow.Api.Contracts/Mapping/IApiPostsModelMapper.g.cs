using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiPostsModelMapper
	{
		ApiPostsResponseModel MapRequestToResponse(
			int id,
			ApiPostsRequestModel request);

		ApiPostsRequestModel MapResponseToRequest(
			ApiPostsResponseModel response);

		JsonPatchDocument<ApiPostsRequestModel> CreatePatch(ApiPostsRequestModel model);
	}
}

/*<Codenesium>
    <Hash>91352a71a9c9ed976ab1965e621df2d3</Hash>
</Codenesium>*/