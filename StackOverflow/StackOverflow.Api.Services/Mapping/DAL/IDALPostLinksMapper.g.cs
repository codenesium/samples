using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostLinksMapper
	{
		PostLinks MapBOToEF(
			BOPostLinks bo);

		BOPostLinks MapEFToBO(
			PostLinks efPostLinks);

		List<BOPostLinks> MapEFToBO(
			List<PostLinks> records);
	}
}

/*<Codenesium>
    <Hash>78fc3fc1e98a7d82651306112b0b7943</Hash>
</Codenesium>*/