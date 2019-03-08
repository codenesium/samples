using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiCommentsServerModelMapper
	{
		ApiCommentsServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCommentsServerRequestModel request);

		ApiCommentsServerRequestModel MapServerResponseToRequest(
			ApiCommentsServerResponseModel response);

		ApiCommentsClientRequestModel MapServerResponseToClientRequest(
			ApiCommentsServerResponseModel response);

		JsonPatchDocument<ApiCommentsServerRequestModel> CreatePatch(ApiCommentsServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b58e2f7f6442062cbc5de1b42ed0828d</Hash>
</Codenesium>*/