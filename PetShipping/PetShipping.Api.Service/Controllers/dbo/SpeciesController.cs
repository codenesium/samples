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
	[Route("api/species")]
	[ApiVersion("1.0")]
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
    <Hash>c5cf8ac56276f1c27e6461f233f31f8f</Hash>
</Codenesium>*/