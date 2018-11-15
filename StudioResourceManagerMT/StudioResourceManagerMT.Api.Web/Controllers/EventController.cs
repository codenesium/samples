using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Web
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
    <Hash>1a7428bb527745f457789afb9e314fe0</Hash>
</Codenesium>*/