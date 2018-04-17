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
	[Route("api/purchaseOrderHeaders")]
	[ApiVersion("1.0")]
	public class PurchaseOrderHeaderController: AbstractPurchaseOrderHeaderController
	{
		public PurchaseOrderHeaderController(
			ILogger<PurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPurchaseOrderHeader purchaseOrderHeaderManager
			)
			: base(logger,
			       transactionCoordinator,
			       purchaseOrderHeaderManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>99f6a205d2c0bd937e0e6675067ff5a7</Hash>
</Codenesium>*/