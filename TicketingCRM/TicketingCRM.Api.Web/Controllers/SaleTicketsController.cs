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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/saleTickets")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SaleTicketsController : AbstractSaleTicketsController
	{
		public SaleTicketsController(
			ApiSettings settings,
			ILogger<SaleTicketsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISaleTicketsService saleTicketsService,
			IApiSaleTicketsModelMapper saleTicketsModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       saleTicketsService,
			       saleTicketsModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e284bc4f45c785f69ff5aeec66a26f26</Hash>
</Codenesium>*/