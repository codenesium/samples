using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALDeploymentRelatedMachineMapper
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
    <Hash>f9924f2dc2eb9870fa151da42c36bb06</Hash>
</Codenesium>*/