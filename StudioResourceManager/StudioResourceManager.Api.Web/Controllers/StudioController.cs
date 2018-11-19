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
    <Hash>f0d919b4787f3668d7da1d7b25a4f74d</Hash>
</Codenesium>*/