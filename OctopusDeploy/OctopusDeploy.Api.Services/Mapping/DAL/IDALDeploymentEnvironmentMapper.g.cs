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
    <Hash>45c670bf04254b873c442ac25571ae1e</Hash>
</Codenesium>*/