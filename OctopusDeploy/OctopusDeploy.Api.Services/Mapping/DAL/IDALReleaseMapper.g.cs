using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALReleaseMapper
	{
		Release MapBOToEF(
			BORelease bo);

		BORelease MapEFToBO(
			Release efRelease);

		List<BORelease> MapEFToBO(
			List<Release> records);
	}
}

/*<Codenesium>
    <Hash>b5829981e29908625862e388c959e645</Hash>
</Codenesium>*/