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
	[Route("api/purchaseOrderHeaders")]
	[ApiVersion("1.0")]
	public class PurchaseOrderHeaderController: AbstractPurchaseOrderHeaderController
	{
		public PurchaseOrderHeaderController(
			ServiceSettings settings,
			ILogger<PurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPurchaseOrderHeader purchaseOrderHeaderManager
			)
			: base(settings,
			       logger,
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
    <Hash>09c8fe08cda3426fb7438331655b754a</Hash>
</Codenesium>*/