using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Web
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
			IApiRateModelMapper rateModelMapper
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
    <Hash>4a8385979d8b76706d2dc134e449234a</Hash>
</Codenesium>*/