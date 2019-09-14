using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiVoteServerModelMapper
	{
		ApiVoteServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVoteServerRequestModel request);

		ApiVoteServerRequestModel MapServerResponseToRequest(
			ApiVoteServerResponseModel response);

		ApiVoteClientRequestModel MapServerResponseToClientRequest(
			ApiVoteServerResponseModel response);

		JsonPatchDocument<ApiVoteServerRequestModel> CreatePatch(ApiVoteServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e55566712f5d40234f0caf4dc4f87196</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/