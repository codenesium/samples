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
	[Route("api/shipMethods")]
	[ApiVersion("1.0")]
	public class ShipMethodController: AbstractShipMethodController
	{
		public ShipMethodController(
			ILogger<ShipMethodController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOShipMethod shipMethodManager
			)
			: base(logger,
			       transactionCoordinator,
			       shipMethodManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7e0142f820e5c292077c4a5c1ab488fe</Hash>
</Codenesium>*/