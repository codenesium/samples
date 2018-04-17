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
	[Route("api/products")]
	[ApiVersion("1.0")]
	public class ProductController: AbstractProductController
	{
		public ProductController(
			ILogger<ProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProduct productManager
			)
			: base(logger,
			       transactionCoordinator,
			       productManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1f7600e671cdd4fd31d3eedc2a6ec86d</Hash>
</Codenesium>*/