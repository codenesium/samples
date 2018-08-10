using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiSchemaAPersonModelMapper
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
    <Hash>4b7cbf87a942540dbea710c1fe6a4ca9</Hash>
</Codenesium>*/