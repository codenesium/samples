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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/purchaseOrderDetails")]
	[ApiVersion("1.0")]
	public class PurchaseOrderDetailController: AbstractPurchaseOrderDetailController
	{
		public PurchaseOrderDetailController(
			ServiceSettings settings,
			ILogger<PurchaseOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderDetailService purchaseOrderDetailService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       purchaseOrderDetailService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>63008d3a08e2bdfeb50bbe7515f67ef8</Hash>
</Codenesium>*/