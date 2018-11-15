using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Web
{
	[Route("api/species")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class SpeciesController : AbstractSpeciesController
	{
		public SpeciesController(
			ApiSettings settings,
			ILogger<SpeciesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpeciesService speciesService,
			IApiSpeciesServerModelMapper speciesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       speciesService,
			       speciesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f4cacd8f1494c39331a8df8669ac0ab4</Hash>
</Codenesium>*/