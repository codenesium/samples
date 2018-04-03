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
	public class SalesOrderHeaderSalesReasonRepository: AbstractSalesOrderHeaderSalesReasonRepository, ISalesOrderHeaderSalesReasonRepository
	{
		public SalesOrderHeaderSalesReasonRepository(ILogger<SalesOrderHeaderSalesReasonRepository> logger,
		                                             ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFSalesOrderHeaderSalesReason> SearchLinqEF(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy("salesOrderID ASC").Skip(skip).Take(take).ToList<EFSalesOrderHeaderSalesReason>();
			}
			else
			{
				return this._context.Set<EFSalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesOrderHeaderSalesReason>();
			}
		}

		protected override List<EFSalesOrderHeaderSalesReason> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy("salesOrderID ASC").Skip(skip).Take(take).ToList<EFSalesOrderHeaderSalesReason>();
			}
			else
			{
				return this._context.Set<EFSalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesOrderHeaderSalesReason>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>b7d1a038f70b4d83b0a83aefacafbae8</Hash>
</Codenesium>*/