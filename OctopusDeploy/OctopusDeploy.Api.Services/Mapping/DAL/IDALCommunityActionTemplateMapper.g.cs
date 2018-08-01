using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALCommunityActionTemplateMapper
	{
		CommunityActionTemplate MapBOToEF(
			BOCommunityActionTemplate bo);

		BOCommunityActionTemplate MapEFToBO(
			CommunityActionTemplate efCommunityActionTemplate);

		List<BOCommunityActionTemplate> MapEFToBO(
			List<CommunityActionTemplate> records);
	}
}

/*<Codenesium>
    <Hash>a6295c2a15e428f503689a97732fa6f8</Hash>
</Codenesium>*/