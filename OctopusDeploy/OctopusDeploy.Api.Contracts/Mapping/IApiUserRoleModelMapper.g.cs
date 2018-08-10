using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiUserRoleModelMapper
	{
		ApiUserRoleResponseModel MapRequestToResponse(
			string id,
			ApiUserRoleRequestModel request);

		ApiUserRoleRequestModel MapResponseToRequest(
			ApiUserRoleResponseModel response);

		JsonPatchDocument<ApiUserRoleRequestModel> CreatePatch(ApiUserRoleRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8c96cea927934abf5e2a2a82e4807e08</Hash>
</Codenesium>*/