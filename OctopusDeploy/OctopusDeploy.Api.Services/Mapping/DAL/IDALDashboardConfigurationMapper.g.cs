using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALDashboardConfigurationMapper
	{
		DashboardConfiguration MapBOToEF(
			BODashboardConfiguration bo);

		BODashboardConfiguration MapEFToBO(
			DashboardConfiguration efDashboardConfiguration);

		List<BODashboardConfiguration> MapEFToBO(
			List<DashboardConfiguration> records);
	}
}

/*<Codenesium>
    <Hash>b0a45da0da2a892fe23c828b8725ff16</Hash>
</Codenesium>*/