using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productVendors")]
	[ApiVersion("1.0")]
	public class ProductVendorController: AbstractProductVendorController
	{
		public ProductVendorController(
			ILogger<ProductVendorController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductVendor productVendorManager
			)
			: base(logger,
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
    <Hash>90adc1e972b8ec27e708eab81c018975</Hash>
</Codenesium>*/