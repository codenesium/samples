using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>024d72082de0d1038e167f7f5a16f3a7</Hash>
</Codenesium>*/