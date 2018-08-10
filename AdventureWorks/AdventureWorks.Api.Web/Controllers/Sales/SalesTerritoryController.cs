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
	[Route("api/salesTerritories")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SalesTerritoryController : AbstractSalesTerritoryController
	{
		public SalesTerritoryController(
			ApiSettings settings,
			ILogger<SalesTerritoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTerritoryService salesTerritoryService,
			IApiSalesTerritoryModelMapper salesTerritoryModelMapper
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
    <Hash>f6b9c7eda41933a59db73ca8fb98550f</Hash>
</Codenesium>*/