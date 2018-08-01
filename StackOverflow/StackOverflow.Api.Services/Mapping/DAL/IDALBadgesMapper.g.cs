using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALBadgesMapper
	{
		Badges MapBOToEF(
			BOBadges bo);

		BOBadges MapEFToBO(
			Badges efBadges);

		List<BOBadges> MapEFToBO(
			List<Badges> records);
	}
}

/*<Codenesium>
    <Hash>82749a696e5dec5e280dd756466bc654</Hash>
</Codenesium>*/