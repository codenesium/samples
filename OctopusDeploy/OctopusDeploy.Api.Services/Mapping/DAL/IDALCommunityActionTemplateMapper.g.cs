using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALCommunityActionTemplateMapper
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
    <Hash>d3dacbdac69d13a7a901bb1ca1087110</Hash>
</Codenesium>*/