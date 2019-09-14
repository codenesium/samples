using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiFollowingServerModelMapper
	{
		ApiFollowingServerResponseModel MapServerRequestToResponse(
			int userId,
			ApiFollowingServerRequestModel request);

		ApiFollowingServerRequestModel MapServerResponseToRequest(
			ApiFollowingServerResponseModel response);

		ApiFollowingClientRequestModel MapServerResponseToClientRequest(
			ApiFollowingServerResponseModel response);

		JsonPatchDocument<ApiFollowingServerRequestModel> CreatePatch(ApiFollowingServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>04a3bfecde612055eb03bdd6620a4d46</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/