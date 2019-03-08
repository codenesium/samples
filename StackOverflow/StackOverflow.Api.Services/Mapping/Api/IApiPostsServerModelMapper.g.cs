using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostsServerModelMapper
	{
		ApiPostsServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostsServerRequestModel request);

		ApiPostsServerRequestModel MapServerResponseToRequest(
			ApiPostsServerResponseModel response);

		ApiPostsClientRequestModel MapServerResponseToClientRequest(
			ApiPostsServerResponseModel response);

		JsonPatchDocument<ApiPostsServerRequestModel> CreatePatch(ApiPostsServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f2f949678f2fd12deefd7a92522f84cc</Hash>
</Codenesium>*/