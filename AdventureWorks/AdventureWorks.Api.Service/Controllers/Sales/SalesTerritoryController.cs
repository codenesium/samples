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
	public class SalesTerritoriesController: AbstractSalesTerritoriesController
	{
		public SalesTerritoriesController(
			ILogger<SalesTerritoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryRepository salesTerritoryRepository,
			ISalesTerritoryModelValidator salesTerritoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         salesTerritoryRepository,
			         salesTerritoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0948cb76f4f40516ec305093b3d4c6d8</Hash>
</Codenesium>*/