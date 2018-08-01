using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/countries")]
	[ApiController]
	[ApiVersion("1.0")]
	public class CountryController : AbstractCountryController
	{
		public CountryController(
			ApiSettings settings,
			ILogger<CountryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryService countryService,
			IApiCountryModelMapper countryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryService,
			       countryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ab2ee50cbb59dff588019b42b30e8949</Hash>
</Codenesium>*/