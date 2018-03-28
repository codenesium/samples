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
	public class ChainStatusRepository: AbstractChainStatusRepository, IChainStatusRepository
	{
		public ChainStatusRepository(ILogger<ChainStatusRepository> logger,
		                             ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFChainStatus> SearchLinqEF(Expression<Func<EFChainStatus, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFChainStatus>();
			}
			else
			{
				return this._context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFChainStatus>();
			}
		}

		protected override List<EFChainStatus> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFChainStatus>();
			}
			else
			{
				return this._context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFChainStatus>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a11d9a4104b55428c355c038db3ea823</Hash>
</Codenesium>*/