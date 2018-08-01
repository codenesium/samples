using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/dashboardConfigurations")]
	[ApiController]
	[ApiVersion("1.0")]
	public class DashboardConfigurationController : AbstractDashboardConfigurationController
	{
		public DashboardConfigurationController(
			ApiSettings settings,
			ILogger<DashboardConfigurationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDashboardConfigurationService dashboardConfigurationService,
			IApiDashboardConfigurationModelMapper dashboardConfigurationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       dashboardConfigurationService,
			       dashboardConfigurationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fb2692dc1a0977f85a01511e95f60cfc</Hash>
</Codenesium>*/