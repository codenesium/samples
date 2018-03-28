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
	public class TeamRepository: AbstractTeamRepository, ITeamRepository
	{
		public TeamRepository(ILogger<TeamRepository> logger,
		                      ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFTeam> SearchLinqEF(Expression<Func<EFTeam, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFTeam>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFTeam>();
			}
			else
			{
				return this._context.Set<EFTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTeam>();
			}
		}

		protected override List<EFTeam> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFTeam>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFTeam>();
			}
			else
			{
				return this._context.Set<EFTeam>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFTeam>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>22bf28b717cf59fdc79dd726148d2a4c</Hash>
</Codenesium>*/