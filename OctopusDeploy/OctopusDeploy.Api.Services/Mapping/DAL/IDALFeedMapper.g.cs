using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALFeedMapper
	{
		Feed MapBOToEF(
			BOFeed bo);

		BOFeed MapEFToBO(
			Feed efFeed);

		List<BOFeed> MapEFToBO(
			List<Feed> records);
	}
}

/*<Codenesium>
    <Hash>171c322f47b88f98a042b98ba839e0ba</Hash>
</Codenesium>*/