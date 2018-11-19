using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
			IApiCountryRegionServerModelMapper countryRegionModelMapper
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
    <Hash>d9e7025a8bb39e7f74e4ea9a9a4d1fc5</Hash>
</Codenesium>*/