using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiTenantModelMapper
	{
		ApiTenantResponseModel MapRequestToResponse(
			string id,
			ApiTenantRequestModel request);

		ApiTenantRequestModel MapResponseToRequest(
			ApiTenantResponseModel response);

		JsonPatchDocument<ApiTenantRequestModel> CreatePatch(ApiTenantRequestModel model);
	}
}

/*<Codenesium>
    <Hash>6f31f5769c4e389364f5b066572418ad</Hash>
</Codenesium>*/