using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public interface IApiSchemaAPersonModelMapper
	{
		ApiSchemaAPersonResponseModel MapRequestToResponse(
			int id,
			ApiSchemaAPersonRequestModel request);

		ApiSchemaAPersonRequestModel MapResponseToRequest(
			ApiSchemaAPersonResponseModel response);

		JsonPatchDocument<ApiSchemaAPersonRequestModel> CreatePatch(ApiSchemaAPersonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>56c9af8e433a3ba3c0d47b986b14097b</Hash>
</Codenesium>*/