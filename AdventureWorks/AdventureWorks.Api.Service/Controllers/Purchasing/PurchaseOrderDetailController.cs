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
	public class PurchaseOrderDetailController: AbstractPurchaseOrderDetailController
	{
		public PurchaseOrderDetailController(
			ILogger<PurchaseOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IPurchaseOrderDetailModelValidator purchaseOrderDetailModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       purchaseOrderDetailRepository,
			       purchaseOrderDetailModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ef71f058e530997caec5d8bce15cb96c</Hash>
</Codenesium>*/