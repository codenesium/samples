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
    <Hash>6c9cd6a9930f2a1e529d594eb22d6f2d</Hash>
</Codenesium>*/