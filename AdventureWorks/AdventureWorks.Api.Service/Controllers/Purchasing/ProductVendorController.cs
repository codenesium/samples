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
	[Route("api/productVendors")]
	[ApiVersion("1.0")]
	[Response]
	public class ProductVendorController: AbstractProductVendorController
	{
		public ProductVendorController(
			ServiceSettings settings,
			ILogger<ProductVendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductVendor productVendorManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productVendorManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cd01dd74e8a04597f8937c8c9b70e07e</Hash>
</Codenesium>*/