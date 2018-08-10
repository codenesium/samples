using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/purchaseOrderDetails")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PurchaseOrderDetailController : AbstractPurchaseOrderDetailController
	{
		public PurchaseOrderDetailController(
			ApiSettings settings,
			ILogger<PurchaseOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderDetailService purchaseOrderDetailService,
			IApiPurchaseOrderDetailModelMapper purchaseOrderDetailModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       purchaseOrderDetailService,
			       purchaseOrderDetailModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f7554b07239905a9b21148bbeb0d48f7</Hash>
</Codenesium>*/