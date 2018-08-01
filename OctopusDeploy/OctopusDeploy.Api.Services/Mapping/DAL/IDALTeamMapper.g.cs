using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALTeamMapper
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
    <Hash>1c2d22649ac260a29b8e40d3629f19cc</Hash>
</Codenesium>*/