using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/scrapReasons")]
	[ApiVersion("1.0")]
	[Response]
	public class ScrapReasonController: AbstractScrapReasonController
	{
		public ScrapReasonController(
			ServiceSettings settings,
			ILogger<ScrapReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOScrapReason scrapReasonManager
			)
			: base(settings,
			       logger,
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
    <Hash>4786209f574f500f560790a9a73f3a04</Hash>
</Codenesium>*/