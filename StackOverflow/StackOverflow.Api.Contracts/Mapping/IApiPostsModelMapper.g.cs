using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiPostsModelMapper
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
    <Hash>8f45bff8ccb9bef050645353e7a24b61</Hash>
</Codenesium>*/