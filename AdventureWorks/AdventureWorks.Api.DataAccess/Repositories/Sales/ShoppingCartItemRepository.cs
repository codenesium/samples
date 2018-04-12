using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ShoppingCartItemRepository: AbstractShoppingCartItemRepository, IShoppingCartItemRepository
	{
		public ShoppingCartItemRepository(
			ILogger<ShoppingCartItemRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFShoppingCartItem> SearchLinqEF(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy("ShoppingCartItemID ASC").Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
			else
			{
				return this.context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
		}

		protected override List<EFShoppingCartItem> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy("ShoppingCartItemID ASC").Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
			else
			{
				return this.context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>53dd960172194f1f3d5b0a5c2975ecd4</Hash>
</Codenesium>*/