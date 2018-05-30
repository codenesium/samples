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
	[Route("api/airTransports")]
	[ApiVersion("1.0")]
	public class AirTransportController: AbstractAirTransportController
	{
		public AirTransportController(
			ServiceSettings settings,
			ILogger<AirTransportController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOAirTransport airTransportManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       airTransportManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4a065e55f32d14a88358eed084c7e702</Hash>
</Codenesium>*/