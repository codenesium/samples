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
	public class ChainRepository: AbstractChainRepository
	{
		public ChainRepository(ILogger<ChainRepository> logger,
		                       ApplicationContext context) : base(logger,context)
		{}

		protected override List<Chain> SearchLinqEF(Expression<Func<Chain, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Chain>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Chain>();
			}
			else
			{
				return this._context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Chain>();
			}
		}

		protected override List<Chain> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Chain>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Chain>();
			}
			else
			{
				return this._context.Set<Chain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Chain>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>8accea8f12e5e2bc5484a38da6297942</Hash>
</Codenesium>*/