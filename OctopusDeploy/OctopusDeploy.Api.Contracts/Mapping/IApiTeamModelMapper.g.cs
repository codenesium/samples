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
    <Hash>d8067e1629a562b6a8853cdf08c984df</Hash>
</Codenesium>*/