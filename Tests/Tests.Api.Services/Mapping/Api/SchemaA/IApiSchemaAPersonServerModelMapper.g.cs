using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiSchemaAPersonServerModelMapper
	{
		ApiSchemaAPersonServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSchemaAPersonServerRequestModel request);

		ApiSchemaAPersonServerRequestModel MapServerResponseToRequest(
			ApiSchemaAPersonServerResponseModel response);

		ApiSchemaAPersonClientRequestModel MapServerResponseToClientRequest(
			ApiSchemaAPersonServerResponseModel response);

		JsonPatchDocument<ApiSchemaAPersonServerRequestModel> CreatePatch(ApiSchemaAPersonServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>15930b5928a529cdc6b49fec1cabd759</Hash>
</Codenesium>*/