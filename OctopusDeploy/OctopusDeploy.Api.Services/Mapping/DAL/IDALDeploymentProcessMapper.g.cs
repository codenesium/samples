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
    <Hash>21f63493ac21eed1aa181c56a3c58144</Hash>
</Codenesium>*/