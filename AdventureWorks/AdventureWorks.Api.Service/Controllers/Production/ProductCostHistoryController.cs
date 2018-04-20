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
	[Route("api/productCostHistories")]
	[ApiVersion("1.0")]
	[Response]
	public class ProductCostHistoryController: AbstractProductCostHistoryController
	{
		public ProductCostHistoryController(
			ServiceSettings settings,
			ILogger<ProductCostHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductCostHistory productCostHistoryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productCostHistoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d0de4f81539a5afa4c25fddc2cb111de</Hash>
</Codenesium>*/