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
	[Route("api/shipMethods")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ShipMethodFilter))]
	public class ShipMethodController: AbstractShipMethodController
	{
		public ShipMethodController(
			ILogger<ShipMethodController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShipMethodRepository shipMethodRepository
			)
			: base(logger,
			       transactionCoordinator,
			       shipMethodRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9a686abb748f6dda3bc5ce74fc8b1994</Hash>
</Codenesium>*/