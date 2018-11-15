using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	[Route("api/events")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class EventController : AbstractEventController
	{
		public EventController(
			ApiSettings settings,
			ILogger<EventController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEventService eventService,
			IApiEventServerModelMapper eventModelMapper
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
    <Hash>9a90ef7e4a71d4601c40e56c8a9f1be5</Hash>
</Codenesium>*/