using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public interface IApiMachineRefTeamModelMapper
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
    <Hash>40baa8db110cbf1133c0f7b03c92f0e6</Hash>
</Codenesium>*/