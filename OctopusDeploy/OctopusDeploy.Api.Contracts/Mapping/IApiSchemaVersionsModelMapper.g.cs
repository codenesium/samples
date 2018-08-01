using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiSchemaVersionsModelMapper
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
    <Hash>3db15aca8becc9408a2566886b6429e7</Hash>
</Codenesium>*/