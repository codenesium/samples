using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALDeploymentRelatedMachineMapper
	{
		DeploymentRelatedMachine MapBOToEF(
			BODeploymentRelatedMachine bo);

		BODeploymentRelatedMachine MapEFToBO(
			DeploymentRelatedMachine efDeploymentRelatedMachine);

		List<BODeploymentRelatedMachine> MapEFToBO(
			List<DeploymentRelatedMachine> records);
	}
}

/*<Codenesium>
    <Hash>dfd2f0f8ab309a15b13a437d84315cdb</Hash>
</Codenesium>*/