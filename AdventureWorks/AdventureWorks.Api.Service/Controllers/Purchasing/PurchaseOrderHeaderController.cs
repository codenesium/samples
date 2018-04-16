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
	[Route("api/purchaseOrderHeaders")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(PurchaseOrderHeaderFilter))]
	public class PurchaseOrderHeaderController: AbstractPurchaseOrderHeaderController
	{
		public PurchaseOrderHeaderController(
			ILogger<PurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository
			)
			: base(logger,
			       transactionCoordinator,
			       purchaseOrderHeaderRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e5eb1273e7848c6781306606aa7eb436</Hash>
</Codenesium>*/