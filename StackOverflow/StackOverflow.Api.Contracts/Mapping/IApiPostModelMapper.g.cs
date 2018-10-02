using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiPostModelMapper
	{
		ApiPostResponseModel MapRequestToResponse(
			int id,
			ApiPostRequestModel request);

		ApiPostRequestModel MapResponseToRequest(
			ApiPostResponseModel response);

		JsonPatchDocument<ApiPostRequestModel> CreatePatch(ApiPostRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b24589eaa9f1d5f93306c7c46a3e82df</Hash>
</Codenesium>*/