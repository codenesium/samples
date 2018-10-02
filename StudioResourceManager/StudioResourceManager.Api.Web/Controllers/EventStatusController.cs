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
	[Route("api/eventStatuses")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class EventStatusController : AbstractEventStatusController
	{
		public EventStatusController(
			ApiSettings settings,
			ILogger<EventStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEventStatusService eventStatusService,
			IApiEventStatusModelMapper eventStatusModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       eventStatusService,
			       eventStatusModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>58fa39462d838fd1aff72610c5cf0468</Hash>
</Codenesium>*/