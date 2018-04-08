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
	public class ProductListPriceHistoryRepository: AbstractProductListPriceHistoryRepository, IProductListPriceHistoryRepository
	{
		public ProductListPriceHistoryRepository(ILogger<ProductListPriceHistoryRepository> logger,
		                                         ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFProductListPriceHistory> SearchLinqEF(Expression<Func<EFProductListPriceHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductListPriceHistory>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductListPriceHistory>();
			}
			else
			{
				return this.context.Set<EFProductListPriceHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductListPriceHistory>();
			}
		}

		protected override List<EFProductListPriceHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFProductListPriceHistory>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductListPriceHistory>();
			}
			else
			{
				return this.context.Set<EFProductListPriceHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductListPriceHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>58f015ed529d24a59ca38b4c0f226678</Hash>
</Codenesium>*/