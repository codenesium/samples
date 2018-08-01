using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALDeploymentMapper
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
    <Hash>4c36cec28ecb7b64182b5e7170573de3</Hash>
</Codenesium>*/