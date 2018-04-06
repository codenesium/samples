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
				return this._context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFChainStatus>();
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
				return this._context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFChainStatus>();
			}
			else
			{
				return this._context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFChainStatus>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>9851e1dc05d23d920fb4b4144c7ccf9d</Hash>
</Codenesium>*/