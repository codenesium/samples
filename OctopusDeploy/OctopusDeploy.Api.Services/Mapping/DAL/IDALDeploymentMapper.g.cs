using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALDeploymentMapper
	{
		Deployment MapBOToEF(
			BODeployment bo);

		BODeployment MapEFToBO(
			Deployment efDeployment);

		List<BODeployment> MapEFToBO(
			List<Deployment> records);
	}
}

/*<Codenesium>
    <Hash>950b03cfa3f7fd7202b0bb5958e383b4</Hash>
</Codenesium>*/