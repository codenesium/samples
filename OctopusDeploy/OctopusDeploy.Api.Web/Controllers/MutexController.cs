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
	[Route("api/mutexes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class MutexController : AbstractMutexController
	{
		public MutexController(
			ApiSettings settings,
			ILogger<MutexController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMutexService mutexService,
			IApiMutexModelMapper mutexModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       mutexService,
			       mutexModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b3349c8d44b7e72393a6e6566ddf14a9</Hash>
</Codenesium>*/