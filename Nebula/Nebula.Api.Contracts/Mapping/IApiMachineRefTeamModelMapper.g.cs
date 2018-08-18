using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public partial interface IApiMachineRefTeamModelMapper
	{
		ApiMachineRefTeamResponseModel MapRequestToResponse(
			int id,
			ApiMachineRefTeamRequestModel request);

		ApiMachineRefTeamRequestModel MapResponseToRequest(
			ApiMachineRefTeamResponseModel response);

		JsonPatchDocument<ApiMachineRefTeamRequestModel> CreatePatch(ApiMachineRefTeamRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3d67e6b19d1612076d0fb0e8b46ed68f</Hash>
</Codenesium>*/