using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALDashboardConfigurationMapper
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
    <Hash>8d1cd87d9fdaf46ebe384a6fa628d877</Hash>
</Codenesium>*/