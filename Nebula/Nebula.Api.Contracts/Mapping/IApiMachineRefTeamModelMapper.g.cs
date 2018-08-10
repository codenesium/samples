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
    <Hash>6b8b3d44a1bf8172284791eb69cc887e</Hash>
</Codenesium>*/