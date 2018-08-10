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
    <Hash>bb49e72d1b548dd38a22658cddb65d02</Hash>
</Codenesium>*/