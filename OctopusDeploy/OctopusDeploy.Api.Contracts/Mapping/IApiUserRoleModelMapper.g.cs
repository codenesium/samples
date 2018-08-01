using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiUserRoleModelMapper
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
    <Hash>879ba33819054d0795d82df6b19a35cb</Hash>
</Codenesium>*/