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
	public class CountryRegionCurrencyRepository: AbstractCountryRegionCurrencyRepository, ICountryRegionCurrencyRepository
	{
		public CountryRegionCurrencyRepository(
			IObjectMapper mapper,
			ILogger<CountryRegionCurrencyRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}

		protected override List<EFCountryRegionCurrency> SearchLinqEF(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy("CountryRegionCode ASC").Skip(skip).Take(take).ToList<EFCountryRegionCurrency>();
			}
			else
			{
				return this.context.Set<EFCountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountryRegionCurrency>();
			}
		}

		protected override List<EFCountryRegionCurrency> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.context.Set<EFCountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy("CountryRegionCode ASC").Skip(skip).Take(take).ToList<EFCountryRegionCurrency>();
			}
			else
			{
				return this.context.Set<EFCountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountryRegionCurrency>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>23718707c8bec7d3a8dbf8ec0cc6856a</Hash>
</Codenesium>*/