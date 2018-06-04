using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ShoppingCartItemService: AbstractShoppingCartItemService, IShoppingCartItemService
	{
		public ShoppingCartItemService(
			ILogger<ShoppingCartItemRepository> logger,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator,
			IBOLShoppingCartItemMapper BOLshoppingCartItemMapper,
			IDALShoppingCartItemMapper DALshoppingCartItemMapper)
			: base(logger, shoppingCartItemRepository,
			       shoppingCartItemModelValidator,
			       BOLshoppingCartItemMapper,
			       DALshoppingCartItemMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>a3e9ae494349b88ab49d92312e62b289</Hash>
</Codenesium>*/