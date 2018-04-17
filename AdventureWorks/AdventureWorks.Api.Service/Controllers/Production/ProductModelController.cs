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
    <Hash>46ca1e244ebe468a05c8c5d8b0eaefff</Hash>
</Codenesium>*/