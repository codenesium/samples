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

	public class SaleTicketController : AbstractSaleTicketController
	{
		public SaleTicketController(
			ApiSettings settings,
			ILogger<SaleTicketController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISaleTicketService saleTicketService,
			IApiSaleTicketServerModelMapper saleTicketModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       saleTicketService,
			       saleTicketModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>227eb6536fc59dd6fb99427f39446d39</Hash>
</Codenesium>*/