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
	[Authorize(Policy = "DefaultAccess")]

	public class EventStatuController : AbstractEventStatuController
	{
		public EventStatuController(
			ApiSettings settings,
			ILogger<EventStatuController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEventStatuService eventStatuService,
			IApiEventStatuServerModelMapper eventStatuModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       eventStatuService,
			       eventStatuModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a20570a92d5be4ea51a868bb22fbbcfb</Hash>
</Codenesium>*/