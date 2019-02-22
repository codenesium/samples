using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiPersonServerModelMapper
	{
		ApiPersonServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPersonServerRequestModel request);

		ApiPersonServerRequestModel MapServerResponseToRequest(
			ApiPersonServerResponseModel response);

		ApiPersonClientRequestModel MapServerResponseToClientRequest(
			ApiPersonServerResponseModel response);

		JsonPatchDocument<ApiPersonServerRequestModel> CreatePatch(ApiPersonServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d65030d5f5a63ac369d9ea355e9000ce</Hash>
</Codenesium>*/