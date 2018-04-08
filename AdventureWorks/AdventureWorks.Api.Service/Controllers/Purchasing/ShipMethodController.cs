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
	[Route("api/shipMethods")]
	public class ShipMethodsController: AbstractShipMethodsController
	{
		public ShipMethodsController(
			ILogger<ShipMethodsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShipMethodRepository shipMethodRepository,
			IShipMethodModelValidator shipMethodModelValidator
			) : base(logger,
			         transactionCoordinator,
			         shipMethodRepository,
			         shipMethodModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>739941660afb632d87836efa5efe514a</Hash>
</Codenesium>*/