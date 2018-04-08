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
	[Route("api/purchaseOrderDetails")]
	public class PurchaseOrderDetailsController: AbstractPurchaseOrderDetailsController
	{
		public PurchaseOrderDetailsController(
			ILogger<PurchaseOrderDetailsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator
			) : base(logger,
			         transactionCoordinator,
			         purchaseOrderDetailRepository,
			         purchaseOrderDetailModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9ddb59f442f7a41287ddea43fae47ddd</Hash>
</Codenesium>*/