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
	public class LinkRepository: AbstractLinkRepository
	{
		public LinkRepository(ILogger<LinkRepository> logger,
		                      ApplicationContext context) : base(logger,context)
		{}

		protected override List<Link> SearchLinqEF(Expression<Func<Link, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Link>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Link>();
			}
			else
			{
				return this._context.Set<Link>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Link>();
			}
		}

		protected override List<Link> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Link>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Link>();
			}
			else
			{
				return this._context.Set<Link>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Link>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>1e51fd59b7689a929531ab0003543bfe</Hash>
</Codenesium>*/