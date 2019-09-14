using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public partial interface IApiRetweetServerModelMapper
	{
		ApiRetweetServerResponseModel MapServerRequestToResponse(
			int id,
			ApiRetweetServerRequestModel request);

		ApiRetweetServerRequestModel MapServerResponseToRequest(
			ApiRetweetServerResponseModel response);

		ApiRetweetClientRequestModel MapServerResponseToClientRequest(
			ApiRetweetServerResponseModel response);

		JsonPatchDocument<ApiRetweetServerRequestModel> CreatePatch(ApiRetweetServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4512cf7ebdaeb7712051f26e1d615719</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/