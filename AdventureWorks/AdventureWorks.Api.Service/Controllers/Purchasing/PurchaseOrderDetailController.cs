using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/purchaseOrderDetails")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(PurchaseOrderDetailFilter))]
	public class PurchaseOrderDetailController: AbstractPurchaseOrderDetailController
	{
		public PurchaseOrderDetailController(
			ILogger<PurchaseOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository
			)
			: base(logger,
			       transactionCoordinator,
			       purchaseOrderDetailRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ec87a1d4b0693dadd44c6dee4a4046b0</Hash>
</Codenesium>*/