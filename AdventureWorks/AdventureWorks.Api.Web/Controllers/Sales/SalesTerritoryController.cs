using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
	[Route("api/salesTerritories")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class SalesTerritoryController : AbstractSalesTerritoryController
	{
		public SalesTerritoryController(
			ApiSettings settings,
			ILogger<SalesTerritoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryService salesTerritoryService,
			IApiSalesTerritoryServerModelMapper salesTerritoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesTerritoryService,
			       salesTerritoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8d3d387400243cdd45155f5b8f7866de</Hash>
</Codenesium>*/