using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Web
{
	[Route("api/airlines")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class AirlineController : AbstractAirlineController
	{
		public AirlineController(
			ApiSettings settings,
			ILogger<AirlineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAirlineService airlineService,
			IApiAirlineServerModelMapper airlineModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       airlineService,
			       airlineModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>18a7304e3106134ebb1f93cf1bd02320</Hash>
</Codenesium>*/