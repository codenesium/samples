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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/productSubcategories")]
	[ApiVersion("1.0")]
	public class ProductSubcategoryController: AbstractProductSubcategoryController
	{
		public ProductSubcategoryController(
			ServiceSettings settings,
			ILogger<ProductSubcategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductSubcategoryService productSubcategoryService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productSubcategoryService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2f8d657d18160c8d15ec9ad34aea84f9</Hash>
</Codenesium>*/