using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostTypeServerModelMapper
	{
		ApiPostTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostTypeServerRequestModel request);

		ApiPostTypeServerRequestModel MapServerResponseToRequest(
			ApiPostTypeServerResponseModel response);

		ApiPostTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPostTypeServerResponseModel response);

		JsonPatchDocument<ApiPostTypeServerRequestModel> CreatePatch(ApiPostTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9eaa28dbe67a1a74f345235507524b99</Hash>
</Codenesium>*/