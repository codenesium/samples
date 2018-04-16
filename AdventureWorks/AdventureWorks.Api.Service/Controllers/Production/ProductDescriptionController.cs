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
	[Route("api/productDescriptions")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ProductDescriptionFilter))]
	public class ProductDescriptionController: AbstractProductDescriptionController
	{
		public ProductDescriptionController(
			ILogger<ProductDescriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDescriptionRepository productDescriptionRepository
			)
			: base(logger,
			       transactionCoordinator,
			       productDescriptionRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>336d2742e1011afe70ee0407bb29213c</Hash>
</Codenesium>*/