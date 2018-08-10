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
	[Route("api/ticketStatus")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TicketStatusController : AbstractTicketStatusController
	{
		public TicketStatusController(
			ApiSettings settings,
			ILogger<TicketStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITicketStatusService ticketStatusService,
			IApiTicketStatusModelMapper ticketStatusModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       ticketStatusService,
			       ticketStatusModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d1493cc9bb2038c8e67c6686d665b9e0</Hash>
</Codenesium>*/