using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/countryRegions")]
	public class CountryRegionsController: AbstractCountryRegionsController
	{
		public CountryRegionsController(
			ILogger<CountryRegionsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionRepository countryRegionRepository,
			ICountryRegionModelValidator countryRegionModelValidator
			) : base(logger,
			         transactionCoordinator,
			         countryRegionRepository,
			         countryRegionModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8991f9818e1532750fe0bacd38967c24</Hash>
</Codenesium>*/