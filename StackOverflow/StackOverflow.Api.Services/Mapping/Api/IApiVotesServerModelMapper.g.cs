using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVotesServerModelMapper
	{
		ApiVotesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVotesServerRequestModel request);

		ApiVotesServerRequestModel MapServerResponseToRequest(
			ApiVotesServerResponseModel response);

		ApiVotesClientRequestModel MapServerResponseToClientRequest(
			ApiVotesServerResponseModel response);

		JsonPatchDocument<ApiVotesServerRequestModel> CreatePatch(ApiVotesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2a23e6463fa23cd7e11161bc1a6a6cb0</Hash>
</Codenesium>*/