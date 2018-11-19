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
    <Hash>ac598650a49bcec3e80003521008a837</Hash>
</Codenesium>*/