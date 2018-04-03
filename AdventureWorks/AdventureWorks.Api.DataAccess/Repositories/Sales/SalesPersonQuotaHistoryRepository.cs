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
		                                         ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFSalesPersonQuotaHistory> SearchLinqEF(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFSalesPersonQuotaHistory>();
			}
			else
			{
				return this._context.Set<EFSalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesPersonQuotaHistory>();
			}
		}

		protected override List<EFSalesPersonQuotaHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy("businessEntityID ASC").Skip(skip).Take(take).ToList<EFSalesPersonQuotaHistory>();
			}
			else
			{
				return this._context.Set<EFSalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesPersonQuotaHistory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3dce64b806a209b7bf0f811fff1591a8</Hash>
</Codenesium>*/