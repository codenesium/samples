using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiReplyServerModelMapper
	{
		ApiReplyServerResponseModel MapServerRequestToResponse(
			int replyId,
			ApiReplyServerRequestModel request);

		ApiReplyServerRequestModel MapServerResponseToRequest(
			ApiReplyServerResponseModel response);

		ApiReplyClientRequestModel MapServerResponseToClientRequest(
			ApiReplyServerResponseModel response);

		JsonPatchDocument<ApiReplyServerRequestModel> CreatePatch(ApiReplyServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>125c3e115d0c028591a49704530216e0</Hash>
</Codenesium>*/