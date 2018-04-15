using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionCurrencyRepository
	{
		string Create(CountryRegionCurrencyModel model);

		void Update(string countryRegionCode,
		            CountryRegionCurrencyModel model);

		void Delete(string countryRegionCode);

		ApiResponse GetById(string countryRegionCode);

		POCOCountryRegionCurrency GetByIdDirect(string countryRegionCode);

		ApiResponse GetWhere(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountryRegionCurrency> GetWhereDirect(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>81c6fb6d3332866a71228a2cb50a4cc5</Hash>
</Codenesium>*/