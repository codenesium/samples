using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALMachineRefTeamMapper
	{
		MachineRefTeam MapModelToEntity(
			int id,
			ApiMachineRefTeamServerRequestModel model);

		ApiMachineRefTeamServerResponseModel MapEntityToModel(
			MachineRefTeam item);

		List<ApiMachineRefTeamServerResponseModel> MapEntityToModel(
			List<MachineRefTeam> items);
	}
}

/*<Codenesium>
    <Hash>08f43d2e790203212a5f2cae7c9fcee0</Hash>
</Codenesium>*/