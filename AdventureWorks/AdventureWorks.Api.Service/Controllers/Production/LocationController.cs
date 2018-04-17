using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/locations")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class LocationController: AbstractLocationController
	{
		public LocationController(
			ILogger<LocationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLocation locationManager
			)
			: base(logger,
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
    <Hash>0542bd4b65d4cde5ed9fd052357017a1</Hash>
</Codenesium>*/