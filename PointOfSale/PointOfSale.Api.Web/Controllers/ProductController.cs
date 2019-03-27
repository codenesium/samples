using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Web
{
	[Route("api/products")]
	[ApiController]
	[ApiVersion("1.0")]

	public class ProductController : AbstractProductController
	{
		public ProductController(
			ApiSettings settings,
			ILogger<ProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductService productService,
			IApiProductServerModelMapper productModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productService,
			       productModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d36a13b1368491e19985438ac78faa97</Hash>
</Codenesium>*/