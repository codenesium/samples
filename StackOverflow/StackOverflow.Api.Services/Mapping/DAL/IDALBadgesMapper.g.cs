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
    <Hash>6c5250d3740368f1f824758c59b9202b</Hash>
</Codenesium>*/