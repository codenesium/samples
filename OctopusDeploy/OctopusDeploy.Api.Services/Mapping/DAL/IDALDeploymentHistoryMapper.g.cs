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
    <Hash>fb8f00504753b3aa02e562dcf5a89997</Hash>
</Codenesium>*/