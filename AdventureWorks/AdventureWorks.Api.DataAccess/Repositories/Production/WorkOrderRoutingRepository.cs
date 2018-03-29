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
		                                  ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFWorkOrderRouting> SearchLinqEF(Expression<Func<EFWorkOrderRouting, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFWorkOrderRouting>().Where(predicate).AsQueryable().OrderBy("WorkOrderID ASC").Skip(skip).Take(take).ToList<EFWorkOrderRouting>();
			}
			else
			{
				return this._context.Set<EFWorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFWorkOrderRouting>();
			}
		}

		protected override List<EFWorkOrderRouting> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFWorkOrderRouting>().Where(predicate).AsQueryable().OrderBy("WorkOrderID ASC").Skip(skip).Take(take).ToList<EFWorkOrderRouting>();
			}
			else
			{
				return this._context.Set<EFWorkOrderRouting>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFWorkOrderRouting>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3700fddee4f61b465e207a1cdf5480aa</Hash>
</Codenesium>*/