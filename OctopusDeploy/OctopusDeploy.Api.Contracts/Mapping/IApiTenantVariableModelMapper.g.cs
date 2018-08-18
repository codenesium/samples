using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiTenantVariableModelMapper
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
    <Hash>188a064fcafc6c47c6e96b811feeb47f</Hash>
</Codenesium>*/