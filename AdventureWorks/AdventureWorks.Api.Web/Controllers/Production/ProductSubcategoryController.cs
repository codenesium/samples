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
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/productSubcategories")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProductSubcategoryController : AbstractProductSubcategoryController
	{
		public ProductSubcategoryController(
			ApiSettings settings,
			ILogger<ProductSubcategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductSubcategoryService productSubcategoryService,
			IApiProductSubcategoryModelMapper productSubcategoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productSubcategoryService,
			       productSubcategoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6d5b579861574f6861eb320772e91ec6</Hash>
</Codenesium>*/