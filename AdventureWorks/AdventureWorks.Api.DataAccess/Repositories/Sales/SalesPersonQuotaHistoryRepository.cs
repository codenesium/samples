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
	public class SalesPersonQuotaHistoryRepository: AbstractSalesPersonQuotaHistoryRepository, ISalesPersonQuotaHistoryRepository
	{
		public SalesPersonQuotaHistoryRepository(ILogger<SalesPersonQuotaHistoryRepository> logger,
		                                         ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFSalesPersonQuotaHistory> SearchLinqEF(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFSalesPersonQuotaHistory>();
			}
			else
			{
				return this.context.Set<EFSalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesPersonQuotaHistory>();
			}
		}

		protected override List<EFSalesPersonQuotaHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy("BusinessEntityID ASC").Skip(skip).Take(take).ToList<EFSalesPersonQuotaHistory>();
			}
			else
			{
				return this.context.Set<EFSalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesPersonQuotaHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e089bf233ea2ad052c62fb945a57b2a5</Hash>
</Codenesium>*/