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
	[Route("api/productCostHistories")]
	[ApiVersion("1.0")]
	public class ProductCostHistoryController: AbstractProductCostHistoryController
	{
		public ProductCostHistoryController(
			ServiceSettings settings,
			ILogger<ProductCostHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductCostHistory productCostHistoryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productCostHistoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>18f0559f3b5d6ec02bf13e49e4f0a3f6</Hash>
</Codenesium>*/