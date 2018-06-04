using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/locations")]
	[ApiVersion("1.0")]
	public class LocationController: AbstractLocationController
	{
		public LocationController(
			ServiceSettings settings,
			ILogger<LocationController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILocationService locationService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       locationService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>619f0e697e4b6a83b5f3d247f7737514</Hash>
</Codenesium>*/