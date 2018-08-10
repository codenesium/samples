using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALBadgesMapper
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
    <Hash>6fcd7b7319a7f14015f0f732abfd5713</Hash>
</Codenesium>*/