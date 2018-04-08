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
	public class ProductModelIllustrationsController: AbstractProductModelIllustrationsController
	{
		public ProductModelIllustrationsController(
			ILogger<ProductModelIllustrationsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelIllustrationRepository productModelIllustrationRepository,
			IProductModelIllustrationModelValidator productModelIllustrationModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productModelIllustrationRepository,
			         productModelIllustrationModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6dc6c627873c7fb059a4905906c61582</Hash>
</Codenesium>*/