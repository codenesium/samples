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
	public class LinkRepository: AbstractLinkRepository
	{
		public LinkRepository(ILogger logger,
		                      DbContext context) : base(logger,context)
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
    <Hash>bb15cf16c1ef7125b95ca1b5c5f2095f</Hash>
</Codenesium>*/