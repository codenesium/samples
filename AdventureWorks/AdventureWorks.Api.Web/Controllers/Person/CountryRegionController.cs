using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/countryRegions")]
	[ApiVersion("1.0")]
	public class CountryRegionController: AbstractCountryRegionController
	{
		public CountryRegionController(
			ServiceSettings settings,
			ILogger<CountryRegionController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionService countryRegionService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryRegionService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c4b411abfb4131df2a994983945f58ab</Hash>
</Codenesium>*/