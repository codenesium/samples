using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALDeploymentProcessMapper
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
    <Hash>c0ead535f0b320a944acc52c51c239f1</Hash>
</Codenesium>*/