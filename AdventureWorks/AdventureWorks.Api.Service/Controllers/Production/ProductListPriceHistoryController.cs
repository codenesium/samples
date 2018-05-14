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
	[Route("api/productListPriceHistories")]
	[ApiVersion("1.0")]
	public class ProductListPriceHistoryController: AbstractProductListPriceHistoryController
	{
		public ProductListPriceHistoryController(
			ServiceSettings settings,
			ILogger<ProductListPriceHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductListPriceHistory productListPriceHistoryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productListPriceHistoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5f82878c290bbb07bf8bf826a0f0158f</Hash>
</Codenesium>*/