using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALBadgeMapper
	{
		Badge MapBOToEF(
			BOBadge bo);

		BOBadge MapEFToBO(
			Badge efBadge);

		List<BOBadge> MapEFToBO(
			List<Badge> records);
	}
}

/*<Codenesium>
    <Hash>c8f25fc8032de8ce662641a672bdab42</Hash>
</Codenesium>*/