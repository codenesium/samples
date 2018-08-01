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
	[Route("api/configurations")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ConfigurationController : AbstractConfigurationController
	{
		public ConfigurationController(
			ApiSettings settings,
			ILogger<ConfigurationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IConfigurationService configurationService,
			IApiConfigurationModelMapper configurationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       configurationService,
			       configurationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4be6eb4aea42641ff43157582bfc1052</Hash>
</Codenesium>*/