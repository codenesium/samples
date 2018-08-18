using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class DashboardConfigurationService : AbstractDashboardConfigurationService, IDashboardConfigurationService
	{
		public DashboardConfigurationService(
			ILogger<IDashboardConfigurationRepository> logger,
			IDashboardConfigurationRepository dashboardConfigurationRepository,
			IApiDashboardConfigurationRequestModelValidator dashboardConfigurationModelValidator,
			IBOLDashboardConfigurationMapper boldashboardConfigurationMapper,
			IDALDashboardConfigurationMapper daldashboardConfigurationMapper
			)
			: base(logger,
			       dashboardConfigurationRepository,
			       dashboardConfigurationModelValidator,
			       boldashboardConfigurationMapper,
			       daldashboardConfigurationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>32f640bdd8468f66b33cc68994d7e344</Hash>
</Codenesium>*/