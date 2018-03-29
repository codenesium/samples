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
			ApplicationContext context,
			IScrapReasonRepository scrapReasonRepository,
			IScrapReasonModelValidator scrapReasonModelValidator
			) : base(logger,
			         context,
			         scrapReasonRepository,
			         scrapReasonModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9f630e9fa6961d71496c58cc07177e46</Hash>
</Codenesium>*/