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
			ITransactionCoordinator transactionCoordinator,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IShoppingCartItemModelValidator shoppingCartItemModelValidator
			) : base(logger,
			         transactionCoordinator,
			         shoppingCartItemRepository,
			         shoppingCartItemModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d12d96e7e7be89e68ed368b24ce5d738</Hash>
</Codenesium>*/