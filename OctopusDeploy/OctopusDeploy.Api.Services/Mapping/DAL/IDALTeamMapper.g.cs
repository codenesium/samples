using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
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
    <Hash>1b8f66e276391c217ab4e278cd755780</Hash>
</Codenesium>*/