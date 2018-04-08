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
	public class ScrapReasonsController: AbstractScrapReasonsController
	{
		public ScrapReasonsController(
			ILogger<ScrapReasonsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IScrapReasonRepository scrapReasonRepository,
			IScrapReasonModelValidator scrapReasonModelValidator
			) : base(logger,
			         transactionCoordinator,
			         scrapReasonRepository,
			         scrapReasonModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8c6414c3fd32e932b03f55057156cd0e</Hash>
</Codenesium>*/