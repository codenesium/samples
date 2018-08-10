using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALDeploymentProcessMapper
	{
		DeploymentProcess MapBOToEF(
			BODeploymentProcess bo);

		BODeploymentProcess MapEFToBO(
			DeploymentProcess efDeploymentProcess);

		List<BODeploymentProcess> MapEFToBO(
			List<DeploymentProcess> records);
	}
}

/*<Codenesium>
    <Hash>960c434891b7248409db47cf7cb541eb</Hash>
</Codenesium>*/