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
		                             ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFChainStatus> SearchLinqEF(Expression<Func<EFChainStatus, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFChainStatus>();
			}
			else
			{
				return this.context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFChainStatus>();
			}
		}

		protected override List<EFChainStatus> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFChainStatus>();
			}
			else
			{
				return this.context.Set<EFChainStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFChainStatus>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>6d05f9a8a4c96b83f5f230e806377898</Hash>
</Codenesium>*/