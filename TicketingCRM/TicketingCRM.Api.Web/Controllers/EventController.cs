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
	[Route("api/events")]
	[ApiController]
	[ApiVersion("1.0")]
	public class EventController : AbstractEventController
	{
		public EventController(
			ApiSettings settings,
			ILogger<EventController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEventService eventService,
			IApiEventModelMapper eventModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       eventService,
			       eventModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d2af8d05f2c17e44b75927ea809db015</Hash>
</Codenesium>*/