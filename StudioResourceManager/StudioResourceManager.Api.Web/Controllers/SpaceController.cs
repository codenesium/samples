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
	[Route("api/spaces")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class SpaceController : AbstractSpaceController
	{
		public SpaceController(
			ApiSettings settings,
			ILogger<SpaceController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceService spaceService,
			IApiSpaceServerModelMapper spaceModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       spaceService,
			       spaceModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>41a87aa3652579981be4f09dcbf7a11f</Hash>
</Codenesium>*/