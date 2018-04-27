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
	[Route("api/destinations")]
	[ApiVersion("1.0")]
	[Response]
	public class DestinationController: AbstractDestinationController
	{
		public DestinationController(
			ServiceSettings settings,
			ILogger<DestinationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODestination destinationManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       destinationManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a7c10f9a9220b1f6391c65cde794e323</Hash>
</Codenesium>*/