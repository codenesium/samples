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
	public class PurchaseOrderHeaderRepository: AbstractPurchaseOrderHeaderRepository, IPurchaseOrderHeaderRepository
	{
		public PurchaseOrderHeaderRepository(ILogger<PurchaseOrderHeaderRepository> logger,
		                                     ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFPurchaseOrderHeader> SearchLinqEF(Expression<Func<EFPurchaseOrderHeader, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy("PurchaseOrderID ASC").Skip(skip).Take(take).ToList<EFPurchaseOrderHeader>();
			}
			else
			{
				return this.context.Set<EFPurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPurchaseOrderHeader>();
			}
		}

		protected override List<EFPurchaseOrderHeader> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy("PurchaseOrderID ASC").Skip(skip).Take(take).ToList<EFPurchaseOrderHeader>();
			}
			else
			{
				return this.context.Set<EFPurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPurchaseOrderHeader>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>835722b7e0c2d66081f3d3bdc3687c2b</Hash>
</Codenesium>*/