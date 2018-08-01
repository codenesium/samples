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
    <Hash>1eff70589a2ee4685a1861537c708b82</Hash>
</Codenesium>*/