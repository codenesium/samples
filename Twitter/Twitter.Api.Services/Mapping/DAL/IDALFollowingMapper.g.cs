using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALFollowingMapper
	{
		Following MapBOToEF(
			BOFollowing bo);

		BOFollowing MapEFToBO(
			Following efFollowing);

		List<BOFollowing> MapEFToBO(
			List<Following> records);
	}
}

/*<Codenesium>
    <Hash>35cb3e09e8317d16678a7687243ded2b</Hash>
</Codenesium>*/