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
			ApplicationContext context,
			ILocationRepository locationRepository,
			ILocationModelValidator locationModelValidator
			) : base(logger,
			         context,
			         locationRepository,
			         locationModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5f4b33f3993a37a20c25de8e97902089</Hash>
</Codenesium>*/