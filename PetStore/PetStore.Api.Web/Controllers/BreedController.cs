using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Web
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
    <Hash>d9b4190ee1afb751c7ce6c910934db83</Hash>
</Codenesium>*/