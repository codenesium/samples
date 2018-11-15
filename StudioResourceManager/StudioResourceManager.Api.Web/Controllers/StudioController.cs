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
	[Route("api/studios")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class StudioController : AbstractStudioController
	{
		public StudioController(
			ApiSettings settings,
			ILogger<StudioController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudioService studioService,
			IApiStudioServerModelMapper studioModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       studioService,
			       studioModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>de6f5d619c6a5840bba062acaf979d5a</Hash>
</Codenesium>*/