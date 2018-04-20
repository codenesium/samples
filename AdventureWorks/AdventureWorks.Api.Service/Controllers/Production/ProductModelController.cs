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
	[Route("api/productModels")]
	[ApiVersion("1.0")]
	[Response]
	public class ProductModelController: AbstractProductModelController
	{
		public ProductModelController(
			ServiceSettings settings,
			ILogger<ProductModelController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductModel productModelManager
			)
			: base(settings,
			       logger,
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
    <Hash>73b675ca2c4c709703c379f443f1c7b7</Hash>
</Codenesium>*/