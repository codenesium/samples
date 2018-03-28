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

		protected override List<EFChain> SearchLinqEF(Expression<Func<EFChain, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFChain>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFChain>();
			}
			else
			{
				return this._context.Set<EFChain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFChain>();
			}
		}

		protected override List<EFChain> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFChain>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFChain>();
			}
			else
			{
				return this._context.Set<EFChain>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFChain>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>69bb1cfb90acb479a6e87d5ae387e4fa</Hash>
</Codenesium>*/