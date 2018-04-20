using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/shipMethods")]
	[ApiVersion("1.0")]
	[Response]
	public class ShipMethodController: AbstractShipMethodController
	{
		public ShipMethodController(
			ServiceSettings settings,
			ILogger<ShipMethodController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOShipMethod shipMethodManager
			)
			: base(settings,
			       logger,
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
    <Hash>d99febb96c5431942c1e034931ba4fe2</Hash>
</Codenesium>*/