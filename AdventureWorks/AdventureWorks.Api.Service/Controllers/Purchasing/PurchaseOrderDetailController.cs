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
	[Route("api/purchaseOrderDetails")]
	[ApiVersion("1.0")]
	[Response]
	public class PurchaseOrderDetailController: AbstractPurchaseOrderDetailController
	{
		public PurchaseOrderDetailController(
			ServiceSettings settings,
			ILogger<PurchaseOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPurchaseOrderDetail purchaseOrderDetailManager
			)
			: base(settings,
			       logger,
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
    <Hash>1114624d77f954745b36bee18ec75e40</Hash>
</Codenesium>*/