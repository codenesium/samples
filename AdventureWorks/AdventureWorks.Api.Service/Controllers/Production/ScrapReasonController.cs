using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/scrapReasons")]
	[ApiVersion("1.0")]
	public class ScrapReasonController: AbstractScrapReasonController
	{
		public ScrapReasonController(
			ILogger<ScrapReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOScrapReason scrapReasonManager
			)
			: base(logger,
			       transactionCoordinator,
			       scrapReasonManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7ae78ff59669f1ee3d0f73c9a99dbcfd</Hash>
</Codenesium>*/