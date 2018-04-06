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
		public ShoppingCartItemRepository(ILogger<ShoppingCartItemRepository> logger,
		                                  ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFShoppingCartItem> SearchLinqEF(Expression<Func<EFShoppingCartItem, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy("ShoppingCartItemID ASC").Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
			else
			{
				return this._context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
		}

		protected override List<EFShoppingCartItem> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy("ShoppingCartItemID ASC").Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
			else
			{
				return this._context.Set<EFShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShoppingCartItem>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>5fd1f8673843d4273b401b5eeb7e9ce0</Hash>
</Codenesium>*/