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
	public class ChainRepository: AbstractChainRepository, IChainRepository
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
    <Hash>7ce4d42d742df65d323690cba04c85cc</Hash>
</Codenesium>*/