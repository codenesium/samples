using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALDeploymentEnvironmentMapper
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
    <Hash>3bccb8f266832f81a82eaec816468c84</Hash>
</Codenesium>*/