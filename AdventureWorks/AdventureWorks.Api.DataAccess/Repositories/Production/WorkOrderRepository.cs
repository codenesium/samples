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
		public WorkOrderRepository(ILogger<WorkOrderRepository> logger,
		                           ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFWorkOrder> SearchLinqEF(Expression<Func<EFWorkOrder, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFWorkOrder>().Where(predicate).AsQueryable().OrderBy("workOrderID ASC").Skip(skip).Take(take).ToList<EFWorkOrder>();
			}
			else
			{
				return this._context.Set<EFWorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFWorkOrder>();
			}
		}

		protected override List<EFWorkOrder> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFWorkOrder>().Where(predicate).AsQueryable().OrderBy("workOrderID ASC").Skip(skip).Take(take).ToList<EFWorkOrder>();
			}
			else
			{
				return this._context.Set<EFWorkOrder>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFWorkOrder>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>5fe5bdf2d2ca693a4394822b111e3136</Hash>
</Codenesium>*/