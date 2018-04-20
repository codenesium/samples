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
	[Response]
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
    <Hash>d13b5bd8c104e1c00ffb646a01f447e1</Hash>
</Codenesium>*/