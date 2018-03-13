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
	public class TeamRepository: AbstractTeamRepository
	{
		public TeamRepository(ILogger<TeamRepository> logger,
		                      ApplicationContext context) : base(logger,context)
		{}

		protected override List<Team> SearchLinqEF(Expression<Func<Team, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Team>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Team>();
			}
			else
			{
				return this._context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Team>();
			}
		}

		protected override List<Team> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Team>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Team>();
			}
			else
			{
				return this._context.Set<Team>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Team>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>7d05a0ae5439dce50abf3ae6655e2e61</Hash>
</Codenesium>*/