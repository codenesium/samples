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
	public class MachineRepository: AbstractMachineRepository, IMachineRepository
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
    <Hash>b6f40787c94a91a2b507dc780b13e372</Hash>
</Codenesium>*/