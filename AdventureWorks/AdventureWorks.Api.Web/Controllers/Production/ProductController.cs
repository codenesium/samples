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
    <Hash>65aa41b152b848e0f53a7e15bbb44139</Hash>
</Codenesium>*/