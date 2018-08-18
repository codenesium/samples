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
    <Hash>0be4674fffa1ea3d5a349e3d6166db94</Hash>
</Codenesium>*/