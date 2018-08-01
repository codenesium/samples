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

namespace AdventureWorksNS.Api.Web
{
	[Route("api/shipMethods")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ShipMethodController : AbstractShipMethodController
	{
		public ShipMethodController(
			ApiSettings settings,
			ILogger<ShipMethodController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShipMethodService shipMethodService,
			IApiShipMethodModelMapper shipMethodModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       shipMethodService,
			       shipMethodModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6a8ff3d18b3086da1ada08c4c60f5086</Hash>
</Codenesium>*/