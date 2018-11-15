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
	[Route("api/ticketStatus")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class TicketStatuController : AbstractTicketStatuController
	{
		public TicketStatuController(
			ApiSettings settings,
			ILogger<TicketStatuController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITicketStatuService ticketStatuService,
			IApiTicketStatuServerModelMapper ticketStatuModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       ticketStatuService,
			       ticketStatuModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8988562df69c5f7e8dc59795011874f8</Hash>
</Codenesium>*/