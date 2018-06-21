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
        public class DashboardConfigurationService : AbstractDashboardConfigurationService, IDashboardConfigurationService
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
    <Hash>730b76222da4f987ff64c3e773f9d86e</Hash>
</Codenesium>*/