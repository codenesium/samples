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
		                                             ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFSalesOrderHeaderSalesReason> SearchLinqEF(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy("SalesOrderID ASC").Skip(skip).Take(take).ToList<EFSalesOrderHeaderSalesReason>();
			}
			else
			{
				return this.context.Set<EFSalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesOrderHeaderSalesReason>();
			}
		}

		protected override List<EFSalesOrderHeaderSalesReason> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy("SalesOrderID ASC").Skip(skip).Take(take).ToList<EFSalesOrderHeaderSalesReason>();
			}
			else
			{
				return this.context.Set<EFSalesOrderHeaderSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesOrderHeaderSalesReason>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>ccc091dec17d334e893738c2aefc0549</Hash>
</Codenesium>*/