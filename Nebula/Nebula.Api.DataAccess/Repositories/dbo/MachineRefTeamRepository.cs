using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public class MachineRefTeamRepository: AbstractMachineRefTeamRepository
	{
		public MachineRefTeamRepository(ILogger logger,
		                                DbContext context) : base(logger,context)
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
    <Hash>e0b6edd14a0dd9a52d76aa86385906c5</Hash>
</Codenesium>*/