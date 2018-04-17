using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/countryRegions")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class CountryRegionController: AbstractCountryRegionController
	{
		public CountryRegionController(
			ILogger<CountryRegionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCountryRegion countryRegionManager
			)
			: base(logger,
			       transactionCoordinator,
			       countryRegionManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9255a501d5436f9f3659058942484bc1</Hash>
</Codenesium>*/