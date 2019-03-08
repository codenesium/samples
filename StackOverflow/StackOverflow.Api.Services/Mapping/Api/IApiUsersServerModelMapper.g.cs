using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiUsersServerModelMapper
	{
		ApiUsersServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUsersServerRequestModel request);

		ApiUsersServerRequestModel MapServerResponseToRequest(
			ApiUsersServerResponseModel response);

		ApiUsersClientRequestModel MapServerResponseToClientRequest(
			ApiUsersServerResponseModel response);

		JsonPatchDocument<ApiUsersServerRequestModel> CreatePatch(ApiUsersServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bd9d246129442edd1aefd99c8c3d50d0</Hash>
</Codenesium>*/