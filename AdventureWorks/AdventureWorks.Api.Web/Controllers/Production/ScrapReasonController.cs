using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
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

namespace AdventureWorksNS.Api.Web
{
	[Route("api/scrapReasons")]
	[ApiController]
	[ApiVersion("1.0")]

	public class ScrapReasonController : AbstractScrapReasonController
	{
		public ScrapReasonController(
			ApiSettings settings,
			ILogger<ScrapReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IScrapReasonService scrapReasonService,
			IApiScrapReasonServerModelMapper scrapReasonModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       scrapReasonService,
			       scrapReasonModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c4b841783f69b982c726a78354504a23</Hash>
</Codenesium>*/