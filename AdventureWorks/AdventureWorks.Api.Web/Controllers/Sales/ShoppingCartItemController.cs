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
	[Route("api/shoppingCartItems")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ShoppingCartItemController : AbstractShoppingCartItemController
	{
		public ShoppingCartItemController(
			ApiSettings settings,
			ILogger<ShoppingCartItemController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShoppingCartItemService shoppingCartItemService,
			IApiShoppingCartItemModelMapper shoppingCartItemModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       shoppingCartItemService,
			       shoppingCartItemModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>62cac093bb7c1b090eb079bd9f5de19b</Hash>
</Codenesium>*/