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
	[Route("api/purchaseOrderHeaders")]
	[ApiVersion("1.0")]
	public class PurchaseOrderHeaderController: AbstractPurchaseOrderHeaderController
	{
		public PurchaseOrderHeaderController(
			ServiceSettings settings,
			ILogger<PurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderHeaderService purchaseOrderHeaderService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       purchaseOrderHeaderService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>85ce29a5b07204ce946d58d854151caa</Hash>
</Codenesium>*/