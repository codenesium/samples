using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALFollowerMapper
	{
		Follower MapBOToEF(
			BOFollower bo);

		BOFollower MapEFToBO(
			Follower efFollower);

		List<BOFollower> MapEFToBO(
			List<Follower> records);
	}
}

/*<Codenesium>
    <Hash>08bea0ab1536cb5ee41e2a084f934d3b</Hash>
</Codenesium>*/