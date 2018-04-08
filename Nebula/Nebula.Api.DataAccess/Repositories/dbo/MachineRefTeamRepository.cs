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
		                                ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFMachineRefTeam> SearchLinqEF(Expression<Func<EFMachineRefTeam, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFMachineRefTeam>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFMachineRefTeam>();
			}
			else
			{
				return this.context.Set<EFMachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFMachineRefTeam>();
			}
		}

		protected override List<EFMachineRefTeam> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFMachineRefTeam>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFMachineRefTeam>();
			}
			else
			{
				return this.context.Set<EFMachineRefTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFMachineRefTeam>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>c883a2164e493f2f076eda600c541ed8</Hash>
</Codenesium>*/