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
	[Route("api/eventStatus")]
	[ApiController]
	[ApiVersion("1.0")]

	public class EventStatusController : AbstractEventStatusController
	{
		public EventStatusController(
			ApiSettings settings,
			ILogger<EventStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEventStatusService eventStatusService,
			IApiEventStatusServerModelMapper eventStatusModelMapper
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
    <Hash>f4618a8df4087b3e538a13e1073f09d3</Hash>
</Codenesium>*/