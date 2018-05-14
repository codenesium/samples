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
	[Route("api/productCategories")]
	[ApiVersion("1.0")]
	public class ProductCategoryController: AbstractProductCategoryController
	{
		public ProductCategoryController(
			ServiceSettings settings,
			ILogger<ProductCategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductCategory productCategoryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productCategoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7164242dfcb5c5a6036ba2fe66855619</Hash>
</Codenesium>*/