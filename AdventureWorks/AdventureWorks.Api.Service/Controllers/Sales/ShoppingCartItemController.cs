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
	[Route("api/shoppingCartItems")]
	[ApiVersion("1.0")]
	public class ShoppingCartItemController: AbstractShoppingCartItemController
	{
		public ShoppingCartItemController(
			ServiceSettings settings,
			ILogger<ShoppingCartItemController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOShoppingCartItem shoppingCartItemManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       shoppingCartItemManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4062887227957d709fded65f207d91e3</Hash>
</Codenesium>*/