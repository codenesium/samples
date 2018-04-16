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
	[Route("api/salesTerritories")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(SalesTerritoryFilter))]
	public class SalesTerritoryController: AbstractSalesTerritoryController
	{
		public SalesTerritoryController(
			ILogger<SalesTerritoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryRepository salesTerritoryRepository
			)
			: base(logger,
			       transactionCoordinator,
			       salesTerritoryRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9397bccf1bf20e19c49056abbaf529c7</Hash>
</Codenesium>*/