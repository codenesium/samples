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
	[Route("api/countries")]
	[ApiVersion("1.0")]
	public class CountryController: AbstractCountryController
	{
		public CountryController(
			ServiceSettings settings,
			ILogger<CountryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryService countryService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0df4acbc5b2e03d6f6708f131b229f14</Hash>
</Codenesium>*/