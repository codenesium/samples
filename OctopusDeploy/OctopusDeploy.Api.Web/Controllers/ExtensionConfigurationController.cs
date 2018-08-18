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
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/extensionConfigurations")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ExtensionConfigurationController : AbstractExtensionConfigurationController
	{
		public ExtensionConfigurationController(
			ApiSettings settings,
			ILogger<ExtensionConfigurationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IExtensionConfigurationService extensionConfigurationService,
			IApiExtensionConfigurationModelMapper extensionConfigurationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       extensionConfigurationService,
			       extensionConfigurationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4fe32451a95bc5692873e1824c0c15fa</Hash>
</Codenesium>*/