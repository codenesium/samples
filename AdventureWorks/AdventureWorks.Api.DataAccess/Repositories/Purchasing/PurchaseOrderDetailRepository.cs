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
	public class PurchaseOrderDetailRepository: AbstractPurchaseOrderDetailRepository, IPurchaseOrderDetailRepository
	{
		public PurchaseOrderDetailRepository(ILogger<PurchaseOrderDetailRepository> logger,
		                                     ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFPurchaseOrderDetail> SearchLinqEF(Expression<Func<EFPurchaseOrderDetail, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy("PurchaseOrderID ASC").Skip(skip).Take(take).ToList<EFPurchaseOrderDetail>();
			}
			else
			{
				return this.context.Set<EFPurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPurchaseOrderDetail>();
			}
		}

		protected override List<EFPurchaseOrderDetail> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy("PurchaseOrderID ASC").Skip(skip).Take(take).ToList<EFPurchaseOrderDetail>();
			}
			else
			{
				return this.context.Set<EFPurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPurchaseOrderDetail>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>05bf547583fb05d92c51a53d04545898</Hash>
</Codenesium>*/