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
	public class CurrencyRateRepository: AbstractCurrencyRateRepository, ICurrencyRateRepository
	{
		public CurrencyRateRepository(
			ILogger<CurrencyRateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}

		protected override List<EFCurrencyRate> SearchLinqEF(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy("CurrencyRateID ASC").Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
			else
			{
				return this.context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
		}

		protected override List<EFCurrencyRate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy("CurrencyRateID ASC").Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
			else
			{
				return this.context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>da53e7fe1236bc325485a986458179a7</Hash>
</Codenesium>*/