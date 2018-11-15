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
	[Route("api/airTransports")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class AirTransportController : AbstractAirTransportController
	{
		public AirTransportController(
			ApiSettings settings,
			ILogger<AirTransportController> logger,
			ITransactionCoordinator transactionCoordinator,
			IAirTransportService airTransportService,
			IApiAirTransportServerModelMapper airTransportModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       airTransportService,
			       airTransportModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>349c29e409f45061ea14802df60435c9</Hash>
</Codenesium>*/