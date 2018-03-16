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
	public class MachineRefTeamRepository: AbstractMachineRefTeamRepository, IMachineRefTeamRepository
	{
		public MachineRefTeamRepository(ILogger<MachineRefTeamRepository> logger,
		                                ApplicationContext context) : base(logger,context)
		{}

		protected override List<MachineRefTeam> SearchLinqEF(Expression<Func<MachineRefTeam, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<MachineRefTeam>();
			}
			else
			{
				return this._context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<MachineRefTeam>();
			}
		}

		protected override List<MachineRefTeam> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<MachineRefTeam>();
			}
			else
			{
				return this._context.Set<MachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<MachineRefTeam>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a3c65a2ffec9b4dceaba1cbe6175b253</Hash>
</Codenesium>*/