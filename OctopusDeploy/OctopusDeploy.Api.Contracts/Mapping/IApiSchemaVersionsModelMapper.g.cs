using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiSchemaVersionsModelMapper
	{
		ApiSchemaVersionsResponseModel MapRequestToResponse(
			int id,
			ApiSchemaVersionsRequestModel request);

		ApiSchemaVersionsRequestModel MapResponseToRequest(
			ApiSchemaVersionsResponseModel response);

		JsonPatchDocument<ApiSchemaVersionsRequestModel> CreatePatch(ApiSchemaVersionsRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3442779aedd62fc554daf675fee730a0</Hash>
</Codenesium>*/