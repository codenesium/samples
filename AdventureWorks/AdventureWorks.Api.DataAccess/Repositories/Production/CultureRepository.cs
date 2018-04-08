using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CultureRepository: AbstractCultureRepository, ICultureRepository
	{
		public CultureRepository(ILogger<CultureRepository> logger,
		                         ApplicationDbContext context) : base(logger,context)
		{}

		protected override List<EFCulture> SearchLinqEF(Expression<Func<EFCulture, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCulture>().Where(predicate).AsQueryable().OrderBy("CultureID ASC").Skip(skip).Take(take).ToList<EFCulture>();
			}
			else
			{
				return this.context.Set<EFCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCulture>();
			}
		}

		protected override List<EFCulture> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCulture>().Where(predicate).AsQueryable().OrderBy("CultureID ASC").Skip(skip).Take(take).ToList<EFCulture>();
			}
			else
			{
				return this.context.Set<EFCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCulture>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>eb266eab58f81e7e0eb0a0d77a3ab226</Hash>
</Codenesium>*/