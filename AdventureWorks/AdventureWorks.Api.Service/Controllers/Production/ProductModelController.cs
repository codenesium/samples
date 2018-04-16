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
	[Route("api/productModels")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ProductModelFilter))]
	public class ProductModelController: AbstractProductModelController
	{
		public ProductModelController(
			ILogger<ProductModelController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelRepository productModelRepository
			)
			: base(logger,
			       transactionCoordinator,
			       productModelRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fe4e2cf9cd53bac9ac8c0fe7762059f2</Hash>
</Codenesium>*/