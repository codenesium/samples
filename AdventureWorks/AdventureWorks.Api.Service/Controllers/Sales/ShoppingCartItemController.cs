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
	public class ShoppingCartItemController: AbstractShoppingCartItemController
	{
		public ShoppingCartItemController(
			ILogger<ShoppingCartItemController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IShoppingCartItemModelValidator shoppingCartItemModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       shoppingCartItemRepository,
			       shoppingCartItemModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>53803c8a4e439120cf5c597d8f421790</Hash>
</Codenesium>*/