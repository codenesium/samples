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
    <Hash>d58f80945590e9fa7dfa1783957218d6</Hash>
</Codenesium>*/