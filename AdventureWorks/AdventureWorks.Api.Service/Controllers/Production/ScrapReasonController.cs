using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/scrapReasons")]
	public class ScrapReasonController: AbstractScrapReasonController
	{
		public ScrapReasonController(
			ILogger<ScrapReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IScrapReasonRepository scrapReasonRepository,
			IScrapReasonModelValidator scrapReasonModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       scrapReasonRepository,
			       scrapReasonModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>992f1898327ba0d3c94cacdabd496343</Hash>
</Codenesium>*/