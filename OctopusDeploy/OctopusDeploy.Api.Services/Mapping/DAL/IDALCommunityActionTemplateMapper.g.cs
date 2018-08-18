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
    <Hash>c0fc83bf378757d8d9706fe515c27066</Hash>
</Codenesium>*/