using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiFollowingModelMapper
	{
		ApiFollowingResponseModel MapRequestToResponse(
			string userId,
			ApiFollowingRequestModel request);

		ApiFollowingRequestModel MapResponseToRequest(
			ApiFollowingResponseModel response);

		JsonPatchDocument<ApiFollowingRequestModel> CreatePatch(ApiFollowingRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9458fc62008d943b54b70654b604f0b4</Hash>
</Codenesium>*/