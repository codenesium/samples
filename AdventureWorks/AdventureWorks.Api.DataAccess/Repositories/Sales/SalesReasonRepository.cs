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
	public class SalesReasonRepository: AbstractSalesReasonRepository, ISalesReasonRepository
	{
		public SalesReasonRepository(ILogger<SalesReasonRepository> logger,
		                             ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFSalesReason> SearchLinqEF(Expression<Func<EFSalesReason, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesReason>().Where(predicate).AsQueryable().OrderBy("SalesReasonID ASC").Skip(skip).Take(take).ToList<EFSalesReason>();
			}
			else
			{
				return this._context.Set<EFSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesReason>();
			}
		}

		protected override List<EFSalesReason> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFSalesReason>().Where(predicate).AsQueryable().OrderBy("SalesReasonID ASC").Skip(skip).Take(take).ToList<EFSalesReason>();
			}
			else
			{
				return this._context.Set<EFSalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesReason>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>d5eceaa70806e7e7a2febab7b65442c7</Hash>
</Codenesium>*/