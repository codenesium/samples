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
	[Route("api/productModelIllustrations")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ProductModelIllustrationFilter))]
	public class ProductModelIllustrationController: AbstractProductModelIllustrationController
	{
		public ProductModelIllustrationController(
			ILogger<ProductModelIllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelIllustrationRepository productModelIllustrationRepository
			)
			: base(logger,
			       transactionCoordinator,
			       productModelIllustrationRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e5a3b35bc2688c0c1a15b8cf4cd2d863</Hash>
</Codenesium>*/