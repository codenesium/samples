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
		public CultureRepository(
			IObjectMapper mapper,
			ILogger<CultureRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFCulture> SearchLinqEF(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCulture>().Where(predicate).AsQueryable().OrderBy("CultureID ASC").Skip(skip).Take(take).ToList<EFCulture>();
			}
			else
			{
				return this.context.Set<EFCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCulture>();
			}
		}

		protected override List<EFCulture> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
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
    <Hash>338dabaeacc126f372f559a2fd54b641</Hash>
</Codenesium>*/