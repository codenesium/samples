using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALTeamMapper
	{
		Team MapBOToEF(
			BOTeam bo);

		BOTeam MapEFToBO(
			Team efTeam);

		List<BOTeam> MapEFToBO(
			List<Team> records);
	}
}

/*<Codenesium>
    <Hash>6f245be831cd338225d08a334dbbf15d</Hash>
</Codenesium>*/