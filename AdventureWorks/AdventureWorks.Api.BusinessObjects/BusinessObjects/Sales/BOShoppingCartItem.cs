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
			IApiShoppingCartItemModelValidator shoppingCartItemModelValidator)
			: base(logger, shoppingCartItemRepository, shoppingCartItemModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>4edaabca42e1b9db0341d67ed894aa6f</Hash>
</Codenesium>*/