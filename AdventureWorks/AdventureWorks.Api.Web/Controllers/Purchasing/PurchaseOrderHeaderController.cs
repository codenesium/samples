using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
	[Route("api/purchaseOrderHeaders")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PurchaseOrderHeaderController : AbstractPurchaseOrderHeaderController
	{
		public PurchaseOrderHeaderController(
			ApiSettings settings,
			ILogger<PurchaseOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPurchaseOrderHeaderService purchaseOrderHeaderService,
			IApiPurchaseOrderHeaderServerModelMapper purchaseOrderHeaderModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       purchaseOrderHeaderService,
			       purchaseOrderHeaderModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1aa0c96092e1505a487e8abda85e1f08</Hash>
</Codenesium>*/