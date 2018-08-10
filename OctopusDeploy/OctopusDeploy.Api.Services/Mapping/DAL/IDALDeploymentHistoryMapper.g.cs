using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALDeploymentHistoryMapper
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
    <Hash>823525a046ff4fa3a353a9ab0c9331d7</Hash>
</Codenesium>*/