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
	public class SalesOrderHeaderRepository: AbstractSalesOrderHeaderRepository, ISalesOrderHeaderRepository
	{
		public SalesOrderHeaderRepository(ILogger<SalesOrderHeaderRepository> logger,
		                                  ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFSalesOrderHeader> SearchLinqEF(Expression<Func<EFSalesOrderHeader, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesOrderHeader>().Where(predicate).AsQueryable().OrderBy("salesOrderID ASC").Skip(skip).Take(take).ToList<EFSalesOrderHeader>();
			}
			else
			{
				return this._context.Set<EFSalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesOrderHeader>();
			}
		}

		protected override List<EFSalesOrderHeader> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesOrderHeader>().Where(predicate).AsQueryable().OrderBy("salesOrderID ASC").Skip(skip).Take(take).ToList<EFSalesOrderHeader>();
			}
			else
			{
				return this._context.Set<EFSalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesOrderHeader>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>ae8fdbba70cbfff6cc2bf92758166a68</Hash>
</Codenesium>*/