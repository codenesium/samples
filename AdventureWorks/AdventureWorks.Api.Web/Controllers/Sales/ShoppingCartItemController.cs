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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/shoppingCartItems")]
	[ApiVersion("1.0")]
	public class ShoppingCartItemController: AbstractShoppingCartItemController
	{
		public ShoppingCartItemController(
			ServiceSettings settings,
			ILogger<ShoppingCartItemController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShoppingCartItemService shoppingCartItemService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       shoppingCartItemService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>daa5d8673a4a8259049e7a6fff8fdeee</Hash>
</Codenesium>*/