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
    <Hash>3c1e3251b7323013b8114ffad8e10783</Hash>
</Codenesium>*/