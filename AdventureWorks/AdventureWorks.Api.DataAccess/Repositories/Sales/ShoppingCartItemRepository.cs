using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ShoppingCartItemRepository: AbstractShoppingCartItemRepository, IShoppingCartItemRepository
	{
		public ShoppingCartItemRepository(
			ILogger<ShoppingCartItemRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>2d84e712c630d0f0c449f67d9d419b0f</Hash>
</Codenesium>*/