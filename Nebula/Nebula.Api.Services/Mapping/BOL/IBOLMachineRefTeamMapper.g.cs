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
			List<BOMachineRefTeam> bos);
	}
}

/*<Codenesium>
    <Hash>16fa9d55a658eac8b43047bcc93af275</Hash>
</Codenesium>*/