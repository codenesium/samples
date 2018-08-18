using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiKeyAllocationModelMapper
	{
		ApiKeyAllocationResponseModel MapRequestToResponse(
			string collectionName,
			ApiKeyAllocationRequestModel request);

		ApiKeyAllocationRequestModel MapResponseToRequest(
			ApiKeyAllocationResponseModel response);

		JsonPatchDocument<ApiKeyAllocationRequestModel> CreatePatch(ApiKeyAllocationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c505d8e4e28e60d2c03c1be162c88bad</Hash>
</Codenesium>*/