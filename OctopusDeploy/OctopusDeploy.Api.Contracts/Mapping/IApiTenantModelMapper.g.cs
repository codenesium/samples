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
    <Hash>94366ffe89f9781be77f88cbfe658c05</Hash>
</Codenesium>*/