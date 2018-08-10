using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	public class CountryRequirementController : AbstractCountryRequirementController
	{
		public CountryRequirementController(
			ApiSettings settings,
			ILogger<CountryRequirementController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRequirementService countryRequirementService,
			IApiCountryRequirementModelMapper countryRequirementModelMapper
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
    <Hash>14b6c2036778ee0e1d11facdfd0090c6</Hash>
</Codenesium>*/