using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALDeploymentHistoryMapper
	{
		DeploymentHistory MapBOToEF(
			BODeploymentHistory bo);

		BODeploymentHistory MapEFToBO(
			DeploymentHistory efDeploymentHistory);

		List<BODeploymentHistory> MapEFToBO(
			List<DeploymentHistory> records);
	}
}

/*<Codenesium>
    <Hash>46c22a0578225479efe1e18231e6b608</Hash>
</Codenesium>*/