using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiCommentServerModelMapper
	{
		ApiCommentServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCommentServerRequestModel request);

		ApiCommentServerRequestModel MapServerResponseToRequest(
			ApiCommentServerResponseModel response);

		ApiCommentClientRequestModel MapServerResponseToClientRequest(
			ApiCommentServerResponseModel response);

		JsonPatchDocument<ApiCommentServerRequestModel> CreatePatch(ApiCommentServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>eff25da16b56edd40c5e4c66b2d18b37</Hash>
</Codenesium>*/