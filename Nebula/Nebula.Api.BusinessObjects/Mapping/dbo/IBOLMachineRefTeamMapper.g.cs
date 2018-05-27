using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLMachineRefTeamMapper
	{
		DTOMachineRefTeam MapModelToDTO(
			int id,
			ApiMachineRefTeamRequestModel model);

		ApiMachineRefTeamResponseModel MapDTOToModel(
			DTOMachineRefTeam dtoMachineRefTeam);

		List<ApiMachineRefTeamResponseModel> MapDTOToModel(
			List<DTOMachineRefTeam> dtos);
	}
}

/*<Codenesium>
    <Hash>f4567198ad496bca5c8c2db25e4365eb</Hash>
</Codenesium>*/