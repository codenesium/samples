using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiTenantModelMapper
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
    <Hash>08b24abdeccafdb522eedf0c514976f8</Hash>
</Codenesium>*/