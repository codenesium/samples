using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class MachineRepository: AbstractMachineRepository
	{
		public MachineRepository(ILogger<MachineRepository> logger,
		                         ApplicationContext context) : base(logger,context)
		{}

		protected override List<Machine> SearchLinqEF(Expression<Func<Machine, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Machine>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Machine>();
			}
			else
			{
				return this._context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Machine>();
			}
		}

		protected override List<Machine> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Machine>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Machine>();
			}
			else
			{
				return this._context.Set<Machine>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Machine>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>3bb93d9c4d6b8327f4e852f0e0a15692</Hash>
</Codenesium>*/