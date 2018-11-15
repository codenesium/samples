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
	[Route("api/countryRequirements")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class CountryRequirementController : AbstractCountryRequirementController
	{
		public CountryRequirementController(
			ApiSettings settings,
			ILogger<CountryRequirementController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRequirementService countryRequirementService,
			IApiCountryRequirementServerModelMapper countryRequirementModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryRequirementService,
			       countryRequirementModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6b2e5f272aa208786cf054d6d63552de</Hash>
</Codenesium>*/