using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
    <Hash>c6553caa68e69656b013197ff487ad78</Hash>
</Codenesium>*/