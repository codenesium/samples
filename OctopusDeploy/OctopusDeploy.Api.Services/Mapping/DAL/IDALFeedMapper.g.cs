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
    <Hash>965166e7ba93024ad68986409de84f9f</Hash>
</Codenesium>*/