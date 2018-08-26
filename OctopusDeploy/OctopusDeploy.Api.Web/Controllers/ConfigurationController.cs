using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/configurations")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
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
    <Hash>de23dfafa54fbbc39075794c584fb59e</Hash>
</Codenesium>*/