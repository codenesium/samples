using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
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
    <Hash>f2fe62e230ad5b3e6ed437407386a13d</Hash>
</Codenesium>*/