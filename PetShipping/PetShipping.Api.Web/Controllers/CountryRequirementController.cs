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
	[Route("api/countryRequirements")]
	[ApiVersion("1.0")]
	public class CountryRequirementController: AbstractCountryRequirementController
	{
		public CountryRequirementController(
			ServiceSettings settings,
			ILogger<CountryRequirementController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRequirementService countryRequirementService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryRequirementService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0510d9ebca989b5a06f66f0b2b690ece</Hash>
</Codenesium>*/