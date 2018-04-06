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
	public class ProductInventoryRepository: AbstractProductInventoryRepository, IProductInventoryRepository
	{
		public ProductInventoryRepository(ILogger<ProductInventoryRepository> logger,
		                                  ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFProductInventory> SearchLinqEF(Expression<Func<EFProductInventory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductInventory>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductInventory>();
			}
			else
			{
				return this._context.Set<EFProductInventory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductInventory>();
			}
		}

		protected override List<EFProductInventory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductInventory>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductInventory>();
			}
			else
			{
				return this._context.Set<EFProductInventory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductInventory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2d69caffcc7ade837f0fe47d4b87b8bd</Hash>
</Codenesium>*/