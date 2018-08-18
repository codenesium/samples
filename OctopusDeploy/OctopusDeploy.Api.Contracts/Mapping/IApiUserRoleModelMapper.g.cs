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
    <Hash>961c47aa22d3d1d19bcbc95ac35fc535</Hash>
</Codenesium>*/