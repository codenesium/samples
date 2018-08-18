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
    <Hash>d717672642bdb5c6d8db8fad984f7fe3</Hash>
</Codenesium>*/