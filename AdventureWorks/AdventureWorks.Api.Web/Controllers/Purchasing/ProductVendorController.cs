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
	[Route("api/productVendors")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProductVendorController : AbstractProductVendorController
	{
		public ProductVendorController(
			ApiSettings settings,
			ILogger<ProductVendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductVendorService productVendorService,
			IApiProductVendorModelMapper productVendorModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productVendorService,
			       productVendorModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d64cd212d5ec56826f0ecc7453679b91</Hash>
</Codenesium>*/