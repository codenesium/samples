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
    <Hash>2f77662c0968efd567ab1d972d52e5b4</Hash>
</Codenesium>*/