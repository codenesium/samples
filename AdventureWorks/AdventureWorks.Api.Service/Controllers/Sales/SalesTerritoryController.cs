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
	[Route("api/salesTerritories")]
	public class SalesTerritoryController: AbstractSalesTerritoryController
	{
		public SalesTerritoryController(
			ILogger<SalesTerritoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryRepository salesTerritoryRepository,
			ISalesTerritoryModelValidator salesTerritoryModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       salesTerritoryRepository,
			       salesTerritoryModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4f5700edd3ff625f740d72e1f8df66ef</Hash>
</Codenesium>*/