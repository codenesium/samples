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
	public class LinkRepository: AbstractLinkRepository, ILinkRepository
	{
		public LinkRepository(ILogger<LinkRepository> logger,
		                      ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFLink> SearchLinqEF(Expression<Func<EFLink, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFLink>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLink>();
			}
			else
			{
				return this._context.Set<EFLink>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLink>();
			}
		}

		protected override List<EFLink> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFLink>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFLink>();
			}
			else
			{
				return this._context.Set<EFLink>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLink>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>1dd45a0d48d35e62d64a36bb52fed25e</Hash>
</Codenesium>*/