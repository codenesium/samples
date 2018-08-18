using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public partial interface IApiTeamModelMapper
	{
		ApiTeamResponseModel MapRequestToResponse(
			string id,
			ApiTeamRequestModel request);

		ApiTeamRequestModel MapResponseToRequest(
			ApiTeamResponseModel response);

		JsonPatchDocument<ApiTeamRequestModel> CreatePatch(ApiTeamRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a7af863fb07d969554b33155e7ddc39c</Hash>
</Codenesium>*/