using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Web
{
	[Route("api/airlines")]
	[ApiVersion("1.0")]
	public class AirlineController: AbstractAirlineController
	{
		public AirlineController(
			ServiceSettings settings,
			ILogger<AirlineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAirlineService airlineService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       airlineService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1ab5e08626813bedc9fb3006758abbfe</Hash>
</Codenesium>*/