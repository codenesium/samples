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
using PetShippingNS.Api.BusinessObjects;

namespace PetShippingNS.Api.Service
{
	[Route("api/airlines")]
	[ApiVersion("1.0")]
	[Response]
	public class AirlineController: AbstractAirlineController
	{
		public AirlineController(
			ServiceSettings settings,
			ILogger<AirlineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOAirline airlineManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       airlineManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e66d75e0b029f4d42687845889be3bc8</Hash>
</Codenesium>*/