using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiMachineRefTeamModelMapper
	{
		ApiMachineRefTeamClientResponseModel MapClientRequestToResponse(
			int id,
			ApiMachineRefTeamClientRequestModel request);

		ApiMachineRefTeamClientRequestModel MapClientResponseToRequest(
			ApiMachineRefTeamClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>47a7f7aed8c33ad0919826d98b8144e2</Hash>
</Codenesium>*/