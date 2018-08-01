using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALChannelMapper
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
    <Hash>e866049f5ba97dfd7defd5f6cb58441d</Hash>
</Codenesium>*/