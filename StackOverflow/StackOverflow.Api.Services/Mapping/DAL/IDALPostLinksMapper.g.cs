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
    <Hash>e00a246e36a13e03fa468ad002622fc9</Hash>
</Codenesium>*/