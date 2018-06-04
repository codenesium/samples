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
	[Route("api/species")]
	[ApiVersion("1.0")]
	public class SpeciesController: AbstractSpeciesController
	{
		public SpeciesController(
			ServiceSettings settings,
			ILogger<SpeciesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpeciesService speciesService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       speciesService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fe73eb4e6b2b95b4f004051bf6740066</Hash>
</Codenesium>*/