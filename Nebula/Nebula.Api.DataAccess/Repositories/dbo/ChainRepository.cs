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
	public class ChainRepository: AbstractChainRepository
	{
		public ChainRepository(ILogger logger,
		                       DbContext context) : base(logger,context)
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
    <Hash>99a88236597728a9f90821b25d288c36</Hash>
</Codenesium>*/