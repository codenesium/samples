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
	public class LocationsController: AbstractLocationsController
	{
		public LocationsController(
			ILogger<LocationsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILocationRepository locationRepository,
			ILocationModelValidator locationModelValidator
			) : base(logger,
			         transactionCoordinator,
			         locationRepository,
			         locationModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b07cecb37c827cfe71c78245bbd78253</Hash>
</Codenesium>*/