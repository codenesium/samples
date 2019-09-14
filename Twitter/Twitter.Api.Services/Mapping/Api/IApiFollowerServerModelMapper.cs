using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiFollowerServerModelMapper
	{
		ApiFollowerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiFollowerServerRequestModel request);

		ApiFollowerServerRequestModel MapServerResponseToRequest(
			ApiFollowerServerResponseModel response);

		ApiFollowerClientRequestModel MapServerResponseToClientRequest(
			ApiFollowerServerResponseModel response);

		JsonPatchDocument<ApiFollowerServerRequestModel> CreatePatch(ApiFollowerServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7973c47a0e8f238887b238e4decd7baa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/