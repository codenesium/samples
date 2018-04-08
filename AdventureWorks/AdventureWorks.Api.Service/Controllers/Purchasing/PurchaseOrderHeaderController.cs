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
	[Route("api/purchaseOrderHeaders")]
	public class PurchaseOrderHeadersController: AbstractPurchaseOrderHeadersController
	{
		public PurchaseOrderHeadersController(
			ILogger<PurchaseOrderHeadersController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator
			) : base(logger,
			         transactionCoordinator,
			         purchaseOrderHeaderRepository,
			         purchaseOrderHeaderModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>289d526d6233e21bbc4f2ba9115dec35</Hash>
</Codenesium>*/