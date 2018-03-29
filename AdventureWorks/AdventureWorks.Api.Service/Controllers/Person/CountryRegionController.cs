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
			ApplicationContext context,
			ICountryRegionRepository countryRegionRepository,
			ICountryRegionModelValidator countryRegionModelValidator
			) : base(logger,
			         context,
			         countryRegionRepository,
			         countryRegionModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>836f5f8dbcfcb2728cd1391d987f1ab7</Hash>
</Codenesium>*/