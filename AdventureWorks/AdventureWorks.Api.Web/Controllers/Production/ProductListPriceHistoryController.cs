using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/productListPriceHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProductListPriceHistoryController : AbstractProductListPriceHistoryController
	{
		public ProductListPriceHistoryController(
			ApiSettings settings,
			ILogger<ProductListPriceHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductListPriceHistoryService productListPriceHistoryService,
			IApiProductListPriceHistoryModelMapper productListPriceHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productListPriceHistoryService,
			       productListPriceHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0dcf5ea1b4621f8cf43e12928d56fcbe</Hash>
</Codenesium>*/