using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web
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
    <Hash>e546b5d38f0a09fcda43216787f0c3b3</Hash>
</Codenesium>*/