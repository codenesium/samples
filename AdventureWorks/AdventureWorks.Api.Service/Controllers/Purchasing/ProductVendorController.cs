using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productVendors")]
	[ApiVersion("1.0")]
	public class ProductVendorController: AbstractProductVendorController
	{
		public ProductVendorController(
			ILogger<ProductVendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductVendorRepository productVendorRepository,
			IProductVendorModelValidator productVendorModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productVendorRepository,
			       productVendorModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fb76fd52688b9892d860446d1603f37c</Hash>
</Codenesium>*/