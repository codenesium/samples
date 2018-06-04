using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IDALMachineRefTeamMapper
	{
		MachineRefTeam MapBOToEF(
			BOMachineRefTeam bo);

		BOMachineRefTeam MapEFToBO(
			MachineRefTeam efMachineRefTeam);

		List<BOMachineRefTeam> MapEFToBO(
			List<MachineRefTeam> records);
	}
}

/*<Codenesium>
    <Hash>c5e5efa2bb7e6ac2382eadb84979e411</Hash>
</Codenesium>*/