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
	[Route("api/productModelIllustrations")]
	public class ProductModelIllustrationController: AbstractProductModelIllustrationController
	{
		public ProductModelIllustrationController(
			ILogger<ProductModelIllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IProductModelIllustrationModelValidator productModelIllustrationModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productModelIllustrationRepository,
			       productModelIllustrationModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ba5af601889675df44344d1d2d360aa5</Hash>
</Codenesium>*/