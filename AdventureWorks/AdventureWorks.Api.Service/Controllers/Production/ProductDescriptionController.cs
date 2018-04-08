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
	public class ProductDescriptionsController: AbstractProductDescriptionsController
	{
		public ProductDescriptionsController(
			ILogger<ProductDescriptionsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDescriptionRepository productDescriptionRepository,
			IProductDescriptionModelValidator productDescriptionModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productDescriptionRepository,
			         productDescriptionModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c2295dbc75943d532b66fedda8f3eda4</Hash>
</Codenesium>*/