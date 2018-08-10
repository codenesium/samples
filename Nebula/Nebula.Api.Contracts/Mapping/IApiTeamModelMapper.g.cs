using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiTeamModelMapper
	{
		ApiTeamResponseModel MapRequestToResponse(
			int id,
			ApiTeamRequestModel request);

		ApiTeamRequestModel MapResponseToRequest(
			ApiTeamResponseModel response);

		JsonPatchDocument<ApiTeamRequestModel> CreatePatch(ApiTeamRequestModel model);
	}
}

/*<Codenesium>
    <Hash>08e66c8eb5bf0c0cbb470daff336bcb7</Hash>
</Codenesium>*/