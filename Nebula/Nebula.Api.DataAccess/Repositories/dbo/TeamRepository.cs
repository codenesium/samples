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
	public class TeamRepository: AbstractTeamRepository
	{
		public TeamRepository(ILogger logger,
		                      DbContext context) : base(logger,context)
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
    <Hash>27069f6d5c7b2fcbc9dce09b36e633af</Hash>
</Codenesium>*/