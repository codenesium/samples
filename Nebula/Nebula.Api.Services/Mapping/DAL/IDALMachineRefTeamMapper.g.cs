using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>f255d9079bf8aadcccf0bf0c089330f5</Hash>
</Codenesium>*/