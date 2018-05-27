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
			IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator,
			IBOLShoppingCartItemMapper shoppingCartItemMapper)
			: base(logger, shoppingCartItemRepository, shoppingCartItemModelValidator, shoppingCartItemMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>70d682f3a7da27190d595dc48b0a7cd3</Hash>
</Codenesium>*/