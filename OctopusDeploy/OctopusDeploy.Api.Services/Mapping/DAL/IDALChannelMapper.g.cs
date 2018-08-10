using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALChannelMapper
	{
		Channel MapBOToEF(
			BOChannel bo);

		BOChannel MapEFToBO(
			Channel efChannel);

		List<BOChannel> MapEFToBO(
			List<Channel> records);
	}
}

/*<Codenesium>
    <Hash>19971a915f98ce9c2750c491a1d97c5c</Hash>
</Codenesium>*/