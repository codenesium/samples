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
using PetStoreNS.Api.BusinessObjects;

namespace PetStoreNS.Api.Service
{
	[Route("api/species")]
	[ApiVersion("1.0")]
	[Response]
	public class SpeciesController: AbstractSpeciesController
	{
		public SpeciesController(
			ServiceSettings settings,
			ILogger<SpeciesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpecies speciesManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       speciesManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>91d95e7906feda4fb4274e538953c4f8</Hash>
</Codenesium>*/