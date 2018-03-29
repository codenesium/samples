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
	[Route("api/shoppingCartItems")]
	public class ShoppingCartItemsController: AbstractShoppingCartItemsController
	{
		public ShoppingCartItemsController(
			ILogger<ShoppingCartItemsController> logger,
			ApplicationContext context,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IShoppingCartItemModelValidator shoppingCartItemModelValidator
			) : base(logger,
			         context,
			         shoppingCartItemRepository,
			         shoppingCartItemModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a2676ad0db16d3b8467f92fb1462dd49</Hash>
</Codenesium>*/