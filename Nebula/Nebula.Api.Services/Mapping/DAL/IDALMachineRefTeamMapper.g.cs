using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALMachineRefTeamMapper
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
    <Hash>f709b5a04a0896d64680909f77fbe3eb</Hash>
</Codenesium>*/