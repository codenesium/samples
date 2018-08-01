using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiTenantVariableModelMapper
	{
		ApiTenantVariableResponseModel MapRequestToResponse(
			string id,
			ApiTenantVariableRequestModel request);

		ApiTenantVariableRequestModel MapResponseToRequest(
			ApiTenantVariableResponseModel response);

		JsonPatchDocument<ApiTenantVariableRequestModel> CreatePatch(ApiTenantVariableRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e9bcf247cf5824067d860bea3cf8b27d</Hash>
</Codenesium>*/