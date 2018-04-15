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
	public class CurrencyRepository: AbstractCurrencyRepository, ICurrencyRepository
	{
		public CurrencyRepository(
			IObjectMapper mapper,
			ILogger<CurrencyRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFCurrency> SearchLinqEF(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCurrency>().Where(predicate).AsQueryable().OrderBy("CurrencyCode ASC").Skip(skip).Take(take).ToList<EFCurrency>();
			}
			else
			{
				return this.context.Set<EFCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCurrency>();
			}
		}

		protected override List<EFCurrency> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCurrency>().Where(predicate).AsQueryable().OrderBy("CurrencyCode ASC").Skip(skip).Take(take).ToList<EFCurrency>();
			}
			else
			{
				return this.context.Set<EFCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCurrency>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>5ff72a38aa1cc6b6714ca4501cf303cb</Hash>
</Codenesium>*/