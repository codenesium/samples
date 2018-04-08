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
		                       ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFClasp> SearchLinqEF(Expression<Func<EFClasp, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFClasp>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFClasp>();
			}
			else
			{
				return this.context.Set<EFClasp>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFClasp>();
			}
		}

		protected override List<EFClasp> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFClasp>().Where(predicate).AsQueryable().OrderBy("Id ASC").Skip(skip).Take(take).ToList<EFClasp>();
			}
			else
			{
				return this.context.Set<EFClasp>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFClasp>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>9d45484a82d2ab8b4def55da0fd06c5d</Hash>
</Codenesium>*/