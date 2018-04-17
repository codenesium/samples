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
    <Hash>c18394000afb4f5e057e249c26f6d8ea</Hash>
</Codenesium>*/