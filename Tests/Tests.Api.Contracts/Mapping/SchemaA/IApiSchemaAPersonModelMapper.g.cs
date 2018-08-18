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
    <Hash>d9c773b6e6f565d38f82abc72ab2a566</Hash>
</Codenesium>*/