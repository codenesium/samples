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
	public class ClaspRepository: AbstractClaspRepository, IClaspRepository
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
    <Hash>71554af8475ee09924e2e32ce737882e</Hash>
</Codenesium>*/