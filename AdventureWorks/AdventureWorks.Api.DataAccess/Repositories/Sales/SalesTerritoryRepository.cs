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
	public class SalesTerritoryRepository: AbstractSalesTerritoryRepository, ISalesTerritoryRepository
	{
		public SalesTerritoryRepository(ILogger<SalesTerritoryRepository> logger,
		                                ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFSalesTerritory> SearchLinqEF(Expression<Func<EFSalesTerritory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesTerritory>().Where(predicate).AsQueryable().OrderBy("TerritoryID ASC").Skip(skip).Take(take).ToList<EFSalesTerritory>();
			}
			else
			{
				return this._context.Set<EFSalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesTerritory>();
			}
		}

		protected override List<EFSalesTerritory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesTerritory>().Where(predicate).AsQueryable().OrderBy("TerritoryID ASC").Skip(skip).Take(take).ToList<EFSalesTerritory>();
			}
			else
			{
				return this._context.Set<EFSalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesTerritory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>19e2719b907e4d361b0241c237d63d51</Hash>
</Codenesium>*/