using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALFeedMapper
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
    <Hash>a0d7a92bff4ec65d869cb29cb3a31b5b</Hash>
</Codenesium>*/