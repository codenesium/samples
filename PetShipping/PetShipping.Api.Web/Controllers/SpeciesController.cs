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
	[Route("api/species")]
	[ApiController]
	[ApiVersion("1.0")]

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
    <Hash>e7a86a39ac740bbacf1e31275c98e2fd</Hash>
</Codenesium>*/