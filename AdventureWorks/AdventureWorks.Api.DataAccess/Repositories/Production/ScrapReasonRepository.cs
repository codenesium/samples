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
		public ScrapReasonRepository(
			ILogger<ScrapReasonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFScrapReason> SearchLinqEF(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFScrapReason>().Where(predicate).AsQueryable().OrderBy("ScrapReasonID ASC").Skip(skip).Take(take).ToList<EFScrapReason>();
			}
			else
			{
				return this.context.Set<EFScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFScrapReason>();
			}
		}

		protected override List<EFScrapReason> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFScrapReason>().Where(predicate).AsQueryable().OrderBy("ScrapReasonID ASC").Skip(skip).Take(take).ToList<EFScrapReason>();
			}
			else
			{
				return this.context.Set<EFScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFScrapReason>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>45fe95cd2ef8e7d16d88a03192bc2d86</Hash>
</Codenesium>*/