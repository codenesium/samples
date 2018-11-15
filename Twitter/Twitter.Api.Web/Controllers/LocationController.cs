using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;

namespace TwitterNS.Api.Web
{
	[Route("api/locations")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class LocationController : AbstractLocationController
	{
		public LocationController(
			ApiSettings settings,
			ILogger<LocationController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILocationService locationService,
			IApiLocationServerModelMapper locationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       locationService,
			       locationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2c4758993d77060240f2ce2d28fba1ee</Hash>
</Codenesium>*/