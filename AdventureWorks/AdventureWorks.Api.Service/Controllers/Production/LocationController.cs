using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/locations")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(LocationFilter))]
	public class LocationController: AbstractLocationController
	{
		public LocationController(
			ILogger<LocationController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILocationRepository locationRepository
			)
			: base(logger,
			       transactionCoordinator,
			       locationRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ba827bed3d574f193aaa5d61f82498cc</Hash>
</Codenesium>*/