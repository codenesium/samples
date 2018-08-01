using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>4ddd782725582e8670324520c8dee745</Hash>
</Codenesium>*/