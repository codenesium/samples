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
	[Route("api/nuGetPackages")]
	[ApiController]
	[ApiVersion("1.0")]
	public class NuGetPackageController : AbstractNuGetPackageController
	{
		public NuGetPackageController(
			ApiSettings settings,
			ILogger<NuGetPackageController> logger,
			ITransactionCoordinator transactionCoordinator,
			INuGetPackageService nuGetPackageService,
			IApiNuGetPackageModelMapper nuGetPackageModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       nuGetPackageService,
			       nuGetPackageModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0d4eee07f982b9d9a0b24cb1a0de8143</Hash>
</Codenesium>*/