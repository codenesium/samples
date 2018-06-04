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
	[Route("api/breeds")]
	[ApiVersion("1.0")]
	public class BreedController: AbstractBreedController
	{
		public BreedController(
			ServiceSettings settings,
			ILogger<BreedController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBreedService breedService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       breedService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>be1a7824c9c9882f1d0c3de8149ee994</Hash>
</Codenesium>*/