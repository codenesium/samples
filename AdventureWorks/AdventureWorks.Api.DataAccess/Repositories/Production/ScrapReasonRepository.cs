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
	public class ScrapReasonRepository: AbstractScrapReasonRepository, IScrapReasonRepository
	{
		public ScrapReasonRepository(ILogger<ScrapReasonRepository> logger,
		                             ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFScrapReason> SearchLinqEF(Expression<Func<EFScrapReason, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFScrapReason>().Where(predicate).AsQueryable().OrderBy("scrapReasonID ASC").Skip(skip).Take(take).ToList<EFScrapReason>();
			}
			else
			{
				return this._context.Set<EFScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFScrapReason>();
			}
		}

		protected override List<EFScrapReason> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFScrapReason>().Where(predicate).AsQueryable().OrderBy("scrapReasonID ASC").Skip(skip).Take(take).ToList<EFScrapReason>();
			}
			else
			{
				return this._context.Set<EFScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFScrapReason>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>06d320a6ea276f0534f8201e5f26dccc</Hash>
</Codenesium>*/