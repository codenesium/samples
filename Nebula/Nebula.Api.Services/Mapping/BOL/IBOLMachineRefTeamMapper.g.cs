using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLMachineRefTeamMapper
	{
		BOMachineRefTeam MapModelToBO(
			int id,
			ApiMachineRefTeamRequestModel model);

		ApiMachineRefTeamResponseModel MapBOToModel(
			BOMachineRefTeam boMachineRefTeam);

		List<ApiMachineRefTeamResponseModel> MapBOToModel(
			List<BOMachineRefTeam> items);
	}
}

/*<Codenesium>
    <Hash>4a65367a68b842cf637994de4105a735</Hash>
</Codenesium>*/