using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
	[Route("api/productCategories")]
	[ApiController]
	[ApiVersion("1.0")]

	public class ProductCategoryController : AbstractProductCategoryController
	{
		public ProductCategoryController(
			ApiSettings settings,
			ILogger<ProductCategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductCategoryService productCategoryService,
			IApiProductCategoryServerModelMapper productCategoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productCategoryService,
			       productCategoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1f60ab8b634122af7eb27cb44491543b</Hash>
</Codenesium>*/