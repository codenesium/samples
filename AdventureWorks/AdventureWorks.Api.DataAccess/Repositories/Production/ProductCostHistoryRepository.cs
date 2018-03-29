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
	public class ProductCostHistoryRepository: AbstractProductCostHistoryRepository, IProductCostHistoryRepository
	{
		public ProductCostHistoryRepository(ILogger<ProductCostHistoryRepository> logger,
		                                    ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFProductCostHistory> SearchLinqEF(Expression<Func<EFProductCostHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductCostHistory>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductCostHistory>();
			}
			else
			{
				return this._context.Set<EFProductCostHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductCostHistory>();
			}
		}

		protected override List<EFProductCostHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFProductCostHistory>().Where(predicate).AsQueryable().OrderBy("ProductID ASC").Skip(skip).Take(take).ToList<EFProductCostHistory>();
			}
			else
			{
				return this._context.Set<EFProductCostHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductCostHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>2eeae3f8360771b3c135ff6fd59f1d6f</Hash>
</Codenesium>*/