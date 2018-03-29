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
			ApplicationContext context,
			ISalesTerritoryRepository salesTerritoryRepository,
			ISalesTerritoryModelValidator salesTerritoryModelValidator
			) : base(logger,
			         context,
			         salesTerritoryRepository,
			         salesTerritoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6a49773dd14de2c7963a87937b6efae0</Hash>
</Codenesium>*/