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
		public CountryRegionCurrencyRepository(ILogger<CountryRegionCurrencyRepository> logger,
		                                       ApplicationContext context) : base(logger,context)
		{}

		protected override List<EFCountryRegionCurrency> SearchLinqEF(Expression<Func<EFCountryRegionCurrency, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFCountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy("CountryRegionCode ASC").Skip(skip).Take(take).ToList<EFCountryRegionCurrency>();
			}
			else
			{
				return this._context.Set<EFCountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountryRegionCurrency>();
			}
		}

		protected override List<EFCountryRegionCurrency> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			if(String.IsNullOrEmpty(orderClause))
			{
				return this._context.Set<EFCountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy("CountryRegionCode ASC").Skip(skip).Take(take).ToList<EFCountryRegionCurrency>();
			}
			else
			{
				return this._context.Set<EFCountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCountryRegionCurrency>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a3ebda6abfe74e61bb5505eb45ae7e67</Hash>
</Codenesium>*/