using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALMachineRefTeamMapper
	{
		void MapDTOToEF(
			int id,
			DTOMachineRefTeam dto,
			MachineRefTeam efMachineRefTeam);

		DTOMachineRefTeam MapEFToDTO(
			MachineRefTeam efMachineRefTeam);
	}
}

/*<Codenesium>
    <Hash>d3af378e5aa9ac9645f65730d9595ed1</Hash>
</Codenesium>*/