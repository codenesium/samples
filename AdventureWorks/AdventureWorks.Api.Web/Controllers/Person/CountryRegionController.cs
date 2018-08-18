using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/countryRegions")]
	[ApiController]
	[ApiVersion("1.0")]
	public class CountryRegionController : AbstractCountryRegionController
	{
		public CountryRegionController(
			ApiSettings settings,
			ILogger<CountryRegionController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionService countryRegionService,
			IApiCountryRegionModelMapper countryRegionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryRegionService,
			       countryRegionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d2d32acaf0f249a9082252c47291d63e</Hash>
</Codenesium>*/