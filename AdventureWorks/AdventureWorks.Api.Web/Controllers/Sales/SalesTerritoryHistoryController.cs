using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/salesTerritoryHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SalesTerritoryHistoryController : AbstractSalesTerritoryHistoryController
	{
		public SalesTerritoryHistoryController(
			ApiSettings settings,
			ILogger<SalesTerritoryHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryHistoryService salesTerritoryHistoryService,
			IApiSalesTerritoryHistoryModelMapper salesTerritoryHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesTerritoryHistoryService,
			       salesTerritoryHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3dd8c3d0e176c09ed61ed8c4b9488aca</Hash>
</Codenesium>*/