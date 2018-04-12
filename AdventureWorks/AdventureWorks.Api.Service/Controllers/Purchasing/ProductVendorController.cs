using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productVendors")]
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
    <Hash>4cf6c5826565a8fef3e3b5b0af7c5646</Hash>
</Codenesium>*/