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
	public class ClaspRepository: AbstractClaspRepository
	{
		public ClaspRepository(ILogger<ClaspRepository> logger,
		                       ApplicationContext context) : base(logger,context)
		{}

		protected override List<Clasp> SearchLinqEF(Expression<Func<Clasp, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Clasp>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Clasp>();
			}
			else
			{
				return this._context.Set<Clasp>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Clasp>();
			}
		}

		protected override List<Clasp> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<Clasp>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<Clasp>();
			}
			else
			{
				return this._context.Set<Clasp>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Clasp>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>ed5e8a50734a25cfa368cb45216b2042</Hash>
</Codenesium>*/