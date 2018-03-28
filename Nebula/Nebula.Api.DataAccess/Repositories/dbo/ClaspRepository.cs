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

		protected override List<EFClasp> SearchLinqEF(Expression<Func<EFClasp, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFClasp>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFClasp>();
			}
			else
			{
				return this._context.Set<EFClasp>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFClasp>();
			}
		}

		protected override List<EFClasp> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFClasp>().Where(predicate).AsQueryable().OrderBy("id ASC").Skip(skip).Take(take).ToList<EFClasp>();
			}
			else
			{
				return this._context.Set<EFClasp>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFClasp>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>30dddced1e2c360c692ab9bc603ce8a6</Hash>
</Codenesium>*/