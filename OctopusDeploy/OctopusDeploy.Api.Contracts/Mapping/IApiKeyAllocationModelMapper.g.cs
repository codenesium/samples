using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiKeyAllocationModelMapper
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
    <Hash>0a83de19197093af5325c47e95012a18</Hash>
</Codenesium>*/