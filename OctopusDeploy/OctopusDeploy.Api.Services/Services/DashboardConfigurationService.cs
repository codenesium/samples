using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DashboardConfigurationService: AbstractDashboardConfigurationService, IDashboardConfigurationService
        {
                public DashboardConfigurationService(
                        ILogger<DashboardConfigurationRepository> logger,
                        IDashboardConfigurationRepository dashboardConfigurationRepository,
                        IApiDashboardConfigurationRequestModelValidator dashboardConfigurationModelValidator,
                        IBOLDashboardConfigurationMapper boldashboardConfigurationMapper,
                        IDALDashboardConfigurationMapper daldashboardConfigurationMapper)
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
    <Hash>12096116557e9b29f72d3fea13844b7c</Hash>
</Codenesium>*/