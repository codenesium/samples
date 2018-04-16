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
	[Route("api/shoppingCartItems")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ShoppingCartItemFilter))]
	public class ShoppingCartItemController: AbstractShoppingCartItemController
	{
		public ShoppingCartItemController(
			ILogger<ShoppingCartItemController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShoppingCartItemRepository shoppingCartItemRepository
			)
			: base(logger,
			       transactionCoordinator,
			       shoppingCartItemRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9e3d2808edf8f20b2c8809bc74285f08</Hash>
</Codenesium>*/