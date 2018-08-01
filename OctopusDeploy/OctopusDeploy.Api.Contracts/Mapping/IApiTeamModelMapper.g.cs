using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public interface IApiTeamModelMapper
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
    <Hash>4385f357a0ae56d7e1674ef2ae7105ee</Hash>
</Codenesium>*/