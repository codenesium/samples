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
	public class WorkOrderRepository: AbstractWorkOrderRepository, IWorkOrderRepository
	{
		public WorkOrderRepository(
			IObjectMapper mapper,
			ILogger<WorkOrderRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFWorkOrder> SearchLinqEF(Expression<Func<EFWorkOrder, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFWorkOrder>().Where(predicate).AsQueryable().OrderBy("WorkOrderID ASC").Skip(skip).Take(take).ToList<EFWorkOrder>();
			}
			else
			{
				return this.context.Set<EFWorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFWorkOrder>();
			}
		}

		protected override List<EFWorkOrder> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFWorkOrder>().Where(predicate).AsQueryable().OrderBy("WorkOrderID ASC").Skip(skip).Take(take).ToList<EFWorkOrder>();
			}
			else
			{
				return this.context.Set<EFWorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFWorkOrder>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>824effed9d5a302086c7efe1bc07ea78</Hash>
</Codenesium>*/