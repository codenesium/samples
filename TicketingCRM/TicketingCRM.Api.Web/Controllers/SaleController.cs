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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/sales")]
	[ApiController]
	[ApiVersion("1.0")]

	public class SaleController : AbstractSaleController
	{
		public SaleController(
			ApiSettings settings,
			ILogger<SaleController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISaleService saleService,
			IApiSaleServerModelMapper saleModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       saleService,
			       saleModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>367eebf24d7237ab8fd1df285f58a57b</Hash>
</Codenesium>*/