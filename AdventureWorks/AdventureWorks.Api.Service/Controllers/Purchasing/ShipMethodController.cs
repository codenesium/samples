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
			ApplicationContext context,
			IShipMethodRepository shipMethodRepository,
			IShipMethodModelValidator shipMethodModelValidator
			) : base(logger,
			         context,
			         shipMethodRepository,
			         shipMethodModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7926d5d5354acf2cdf7a662b8e686f7f</Hash>
</Codenesium>*/