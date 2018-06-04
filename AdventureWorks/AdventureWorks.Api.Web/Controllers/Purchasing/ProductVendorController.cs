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
	[Route("api/productVendors")]
	[ApiVersion("1.0")]
	public class ProductVendorController: AbstractProductVendorController
	{
		public ProductVendorController(
			ServiceSettings settings,
			ILogger<ProductVendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductVendorService productVendorService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productVendorService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>330519606b22f4f62fc5f9e042891933</Hash>
</Codenesium>*/