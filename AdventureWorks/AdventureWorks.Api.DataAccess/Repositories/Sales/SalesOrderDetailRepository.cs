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
		public SalesOrderDetailRepository(
			IObjectMapper mapper,
			ILogger<SalesOrderDetailRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFSalesOrderDetail> SearchLinqEF(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesOrderDetail>().Where(predicate).AsQueryable().OrderBy("SalesOrderID ASC").Skip(skip).Take(take).ToList<EFSalesOrderDetail>();
			}
			else
			{
				return this.context.Set<EFSalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesOrderDetail>();
			}
		}

		protected override List<EFSalesOrderDetail> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFSalesOrderDetail>().Where(predicate).AsQueryable().OrderBy("SalesOrderID ASC").Skip(skip).Take(take).ToList<EFSalesOrderDetail>();
			}
			else
			{
				return this.context.Set<EFSalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFSalesOrderDetail>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>acf285429efded893cfbd61a7c380e38</Hash>
</Codenesium>*/