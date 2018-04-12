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
	[Route("api/productDescriptions")]
	public class ProductDescriptionController: AbstractProductDescriptionController
	{
		public ProductDescriptionController(
			ILogger<ProductDescriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDescriptionRepository productDescriptionRepository,
			IProductDescriptionModelValidator productDescriptionModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productDescriptionRepository,
			       productDescriptionModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d1e87b70aad86b3ce9a4d55da8e499fc</Hash>
</Codenesium>*/