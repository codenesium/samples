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
	[Route("api/destinations")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class DestinationController : AbstractDestinationController
	{
		public DestinationController(
			ApiSettings settings,
			ILogger<DestinationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDestinationService destinationService,
			IApiDestinationServerModelMapper destinationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       destinationService,
			       destinationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>25cf3fe84d18d375db987387d138ab15</Hash>
</Codenesium>*/