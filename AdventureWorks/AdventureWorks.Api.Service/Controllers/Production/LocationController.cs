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
	[Response]
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
    <Hash>b4a084e7b7eae95c99eb21b09abe5586</Hash>
</Codenesium>*/