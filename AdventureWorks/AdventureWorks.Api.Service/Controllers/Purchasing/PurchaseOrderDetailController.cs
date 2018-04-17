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
	[Route("api/purchaseOrderDetails")]
	[ApiVersion("1.0")]
	public class PurchaseOrderDetailController: AbstractPurchaseOrderDetailController
	{
		public PurchaseOrderDetailController(
			ILogger<PurchaseOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPurchaseOrderDetail purchaseOrderDetailManager
			)
			: base(logger,
			       transactionCoordinator,
			       purchaseOrderDetailManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1794cc82a88798b11ce4ceee6c113ca0</Hash>
</Codenesium>*/