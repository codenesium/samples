using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/dashboardConfigurations")]
        [ApiVersion("1.0")]
        public class DashboardConfigurationController: AbstractDashboardConfigurationController
        {
                public DashboardConfigurationController(
                        ServiceSettings settings,
                        ILogger<DashboardConfigurationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDashboardConfigurationService dashboardConfigurationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               dashboardConfigurationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ca6445f5c7a6fefb6282dfefd6ca62cd</Hash>
</Codenesium>*/