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
    <Hash>3c3177061072ea096e290f0f98b0acb7</Hash>
</Codenesium>*/