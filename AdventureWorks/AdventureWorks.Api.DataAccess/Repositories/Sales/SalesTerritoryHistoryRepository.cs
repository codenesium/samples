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
	public class SalesTerritoryHistoryRepository: AbstractSalesTerritoryHistoryRepository, ISalesTerritoryHistoryRepository
	{
		public SalesTerritoryHistoryRepository(ILogger<SalesTerritoryHistoryRepository> logger,
		                                       ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFSalesTerritoryHistory> SearchLinqEF(Expression<Func<EFSalesTerritoryHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesTerritoryHistory>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFSalesTerritoryHistory>();
			}
			else
			{
				return this.context.Set<EFSalesTerritoryHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesTerritoryHistory>();
			}
		}

		protected override List<EFSalesTerritoryHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesTerritoryHistory>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFSalesTerritoryHistory>();
			}
			else
			{
				return this.context.Set<EFSalesTerritoryHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesTerritoryHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>f72fced7c16c1546d7f03b31d1744cd5</Hash>
</Codenesium>*/