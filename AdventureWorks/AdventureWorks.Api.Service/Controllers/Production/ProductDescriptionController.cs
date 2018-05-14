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
	[Route("api/productDescriptions")]
	[ApiVersion("1.0")]
	public class ProductDescriptionController: AbstractProductDescriptionController
	{
		public ProductDescriptionController(
			ServiceSettings settings,
			ILogger<ProductDescriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductDescription productDescriptionManager
			)
			: base(settings,
			       logger,
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
    <Hash>d64596084f38e7441535808794ef7f45</Hash>
</Codenesium>*/