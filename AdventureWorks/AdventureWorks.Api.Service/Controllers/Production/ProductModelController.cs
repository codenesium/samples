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
	[Route("api/productModels")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class ProductModelController: AbstractProductModelController
	{
		public ProductModelController(
			ILogger<ProductModelController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductModel productModelManager
			)
			: base(logger,
			       transactionCoordinator,
			       productModelManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>98baeea0edbc0daccb709cdfa22558e3</Hash>
</Codenesium>*/