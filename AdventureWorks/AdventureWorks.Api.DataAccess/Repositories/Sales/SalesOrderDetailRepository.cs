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
	public class SalesOrderDetailRepository: AbstractSalesOrderDetailRepository, ISalesOrderDetailRepository
	{
		public SalesOrderDetailRepository(ILogger<SalesOrderDetailRepository> logger,
		                                  ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFSalesOrderDetail> SearchLinqEF(Expression<Func<EFSalesOrderDetail, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesOrderDetail>().Where(predicate).AsQueryable().OrderBy("salesOrderID ASC").Skip(skip).Take(take).ToList<EFSalesOrderDetail>();
			}
			else
			{
				return this._context.Set<EFSalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesOrderDetail>();
			}
		}

		protected override List<EFSalesOrderDetail> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesOrderDetail>().Where(predicate).AsQueryable().OrderBy("salesOrderID ASC").Skip(skip).Take(take).ToList<EFSalesOrderDetail>();
			}
			else
			{
				return this._context.Set<EFSalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesOrderDetail>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>6b6e5a6982b51d62f40ffea0cb700d41</Hash>
</Codenesium>*/