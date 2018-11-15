using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	[Route("api/rates")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class RateController : AbstractRateController
	{
		public RateController(
			ApiSettings settings,
			ILogger<RateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IRateService rateService,
			IApiRateServerModelMapper rateModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       rateService,
			       rateModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>56c9fb703d7aefefb794455f0160424e</Hash>
</Codenesium>*/