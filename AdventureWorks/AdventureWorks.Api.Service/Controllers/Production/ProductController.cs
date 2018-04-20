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
	[Route("api/products")]
	[ApiVersion("1.0")]
	[Response]
	public class ProductController: AbstractProductController
	{
		public ProductController(
			ServiceSettings settings,
			ILogger<ProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProduct productManager
			)
			: base(settings,
			       logger,
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
    <Hash>d0ed756116200930022c8959833e682b</Hash>
</Codenesium>*/