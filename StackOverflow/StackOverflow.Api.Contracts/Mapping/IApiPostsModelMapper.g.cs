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
    <Hash>b1a196008d4091ddb1462565dba40f60</Hash>
</Codenesium>*/