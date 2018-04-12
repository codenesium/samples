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
		public PurchaseOrderDetailRepository(
			ILogger<PurchaseOrderDetailRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFPurchaseOrderDetail> SearchLinqEF(Expression<Func<EFPurchaseOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFPurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy("PurchaseOrderID ASC").Skip(skip).Take(take).ToList<EFPurchaseOrderDetail>();
			}
			else
			{
				return this.context.Set<EFPurchaseOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFPurchaseOrderDetail>();
			}
		}

		protected override List<EFPurchaseOrderDetail> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
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
    <Hash>f2de6bb88ec3c6a9b4c368b46e0f5110</Hash>
</Codenesium>*/