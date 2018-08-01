using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IBOLMachineRefTeamMapper
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
    <Hash>5926478c2647b4259a381db754045f4c</Hash>
</Codenesium>*/