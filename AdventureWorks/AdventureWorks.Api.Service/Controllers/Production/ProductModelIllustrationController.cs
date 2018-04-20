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
	[Route("api/productModelIllustrations")]
	[ApiVersion("1.0")]
	[Response]
	public class ProductModelIllustrationController: AbstractProductModelIllustrationController
	{
		public ProductModelIllustrationController(
			ServiceSettings settings,
			ILogger<ProductModelIllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductModelIllustration productModelIllustrationManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productModelIllustrationManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>687b2c1bd73960db3a7def2df372bc66</Hash>
</Codenesium>*/