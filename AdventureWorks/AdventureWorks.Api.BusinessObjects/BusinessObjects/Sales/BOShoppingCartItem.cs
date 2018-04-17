using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOShoppingCartItem: AbstractBOShoppingCartItem, IBOShoppingCartItem
	{
		public BOShoppingCartItem(
			ILogger<ShoppingCartItemRepository> logger,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IShoppingCartItemModelValidator shoppingCartItemModelValidator)
			: base(logger, shoppingCartItemRepository, shoppingCartItemModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>882e4d6367cbbdb21e4cad71d8cfd13c</Hash>
</Codenesium>*/