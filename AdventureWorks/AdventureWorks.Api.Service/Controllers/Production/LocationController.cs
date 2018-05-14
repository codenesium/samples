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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/locations")]
	[ApiVersion("1.0")]
	public class LocationController: AbstractLocationController
	{
		public LocationController(
			ServiceSettings settings,
			ILogger<LocationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLocation locationManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       locationManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>537fc1f7d38f24a4fbc323cad5bd6fbd</Hash>
</Codenesium>*/