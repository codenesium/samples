using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALDeploymentEnvironmentMapper
	{
		DeploymentEnvironment MapBOToEF(
			BODeploymentEnvironment bo);

		BODeploymentEnvironment MapEFToBO(
			DeploymentEnvironment efDeploymentEnvironment);

		List<BODeploymentEnvironment> MapEFToBO(
			List<DeploymentEnvironment> records);
	}
}

/*<Codenesium>
    <Hash>c7c5edd5367b47a2cd6ceeab6e45b4a8</Hash>
</Codenesium>*/