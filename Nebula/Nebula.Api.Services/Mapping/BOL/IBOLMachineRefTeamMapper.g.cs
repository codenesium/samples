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
    <Hash>b283f29ee7264c992a4e11cdd5e45d65</Hash>
</Codenesium>*/