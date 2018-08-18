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
    <Hash>ba62c054847661ffd884c0d9bc504f2c</Hash>
</Codenesium>*/