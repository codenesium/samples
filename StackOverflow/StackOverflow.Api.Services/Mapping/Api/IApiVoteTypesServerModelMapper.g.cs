using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVoteTypesServerModelMapper
	{
		ApiVoteTypesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVoteTypesServerRequestModel request);

		ApiVoteTypesServerRequestModel MapServerResponseToRequest(
			ApiVoteTypesServerResponseModel response);

		ApiVoteTypesClientRequestModel MapServerResponseToClientRequest(
			ApiVoteTypesServerResponseModel response);

		JsonPatchDocument<ApiVoteTypesServerRequestModel> CreatePatch(ApiVoteTypesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>456d2dda0d1330a367aeacc42abad325</Hash>
</Codenesium>*/