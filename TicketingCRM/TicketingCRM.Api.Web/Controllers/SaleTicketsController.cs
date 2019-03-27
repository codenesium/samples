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
			IApiSaleTicketsServerModelMapper saleTicketsModelMapper
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
    <Hash>1005d603860ba6b0caf51d9ab22701c9</Hash>
</Codenesium>*/