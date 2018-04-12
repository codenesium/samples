using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/locations")]
	public class LocationController: AbstractLocationController
	{
		public LocationController(
			ILogger<LocationController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILocationRepository locationRepository,
			ILocationModelValidator locationModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       locationRepository,
			       locationModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1670fd0f20d9378b493c930b867d0121</Hash>
</Codenesium>*/