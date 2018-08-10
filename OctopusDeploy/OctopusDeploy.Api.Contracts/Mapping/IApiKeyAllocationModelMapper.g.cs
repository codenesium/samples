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
    <Hash>31aaa61aa201e01b4da510fcb56ae2bb</Hash>
</Codenesium>*/