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
	public class WorkOrderRoutingRepository: AbstractWorkOrderRoutingRepository, IWorkOrderRoutingRepository
	{
		public WorkOrderRoutingRepository(ILogger<WorkOrderRoutingRepository> logger,
		                                  ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFWorkOrderRouting> SearchLinqEF(Expression<Func<EFWorkOrderRouting, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFWorkOrderRouting>().Where(predicate).AsQueryable().OrderBy("WorkOrderID ASC").Skip(skip).Take(take).ToList<EFWorkOrderRouting>();
			}
			else
			{
				return this.context.Set<EFWorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFWorkOrderRouting>();
			}
		}

		protected override List<EFWorkOrderRouting> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFWorkOrderRouting>().Where(predicate).AsQueryable().OrderBy("WorkOrderID ASC").Skip(skip).Take(take).ToList<EFWorkOrderRouting>();
			}
			else
			{
				return this.context.Set<EFWorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFWorkOrderRouting>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>c935bc412ee7becb73bbc10cc062dbf6</Hash>
</Codenesium>*/