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
	[Route("api/productDescriptions")]
	[ApiVersion("1.0")]
	public class ProductDescriptionController: AbstractProductDescriptionController
	{
		public ProductDescriptionController(
			ILogger<ProductDescriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductDescription productDescriptionManager
			)
			: base(logger,
			       transactionCoordinator,
			       productDescriptionManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e032d7e5cc5bcc0013a1f4c4d66e769a</Hash>
</Codenesium>*/