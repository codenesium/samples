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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/countryRegions")]
	[ApiVersion("1.0")]
	[Response]
	public class CountryRegionController: AbstractCountryRegionController
	{
		public CountryRegionController(
			ServiceSettings settings,
			ILogger<CountryRegionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCountryRegion countryRegionManager
			)
			: base(settings,
			       logger,
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
    <Hash>ddd03dc5a7e664d661cdbb9031a1a40e</Hash>
</Codenesium>*/