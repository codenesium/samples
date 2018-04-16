using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/countryRegions")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(CountryRegionFilter))]
	public class CountryRegionController: AbstractCountryRegionController
	{
		public CountryRegionController(
			ILogger<CountryRegionController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionRepository countryRegionRepository
			)
			: base(logger,
			       transactionCoordinator,
			       countryRegionRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>def757cfc7a91e6406a360472ee41337</Hash>
</Codenesium>*/