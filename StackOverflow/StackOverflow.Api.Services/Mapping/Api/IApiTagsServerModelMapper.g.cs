using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiTagsServerModelMapper
	{
		ApiTagsServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTagsServerRequestModel request);

		ApiTagsServerRequestModel MapServerResponseToRequest(
			ApiTagsServerResponseModel response);

		ApiTagsClientRequestModel MapServerResponseToClientRequest(
			ApiTagsServerResponseModel response);

		JsonPatchDocument<ApiTagsServerRequestModel> CreatePatch(ApiTagsServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>cd025220f99659708cad12f96ff88398</Hash>
</Codenesium>*/