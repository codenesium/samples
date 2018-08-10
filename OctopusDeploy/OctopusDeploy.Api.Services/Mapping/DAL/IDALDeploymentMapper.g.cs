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
    <Hash>113f3991d0ba7505456cbed3aa01a94f</Hash>
</Codenesium>*/