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
	public class ClaspRepository: AbstractClaspRepository
	{
		public ClaspRepository(ILogger logger,
		                       DbContext context) : base(logger,context)
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
    <Hash>1c0338fff637bf70f871391b1328e808</Hash>
</Codenesium>*/