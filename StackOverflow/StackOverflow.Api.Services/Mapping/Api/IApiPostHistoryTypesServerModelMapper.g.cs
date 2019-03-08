using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostHistoryTypesServerModelMapper
	{
		ApiPostHistoryTypesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostHistoryTypesServerRequestModel request);

		ApiPostHistoryTypesServerRequestModel MapServerResponseToRequest(
			ApiPostHistoryTypesServerResponseModel response);

		ApiPostHistoryTypesClientRequestModel MapServerResponseToClientRequest(
			ApiPostHistoryTypesServerResponseModel response);

		JsonPatchDocument<ApiPostHistoryTypesServerRequestModel> CreatePatch(ApiPostHistoryTypesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>854882b1cabc09e9aee49900fcff42f0</Hash>
</Codenesium>*/