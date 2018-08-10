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
    <Hash>cfd1d81fcfb679ed15c87d745b149edc</Hash>
</Codenesium>*/