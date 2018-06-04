using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionCurrencyRepository
	{
		Task<CountryRegionCurrency> Create(CountryRegionCurrency item);

		Task Update(CountryRegionCurrency item);

		Task Delete(string countryRegionCode);

		Task<CountryRegionCurrency> Get(string countryRegionCode);

		Task<List<CountryRegionCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<CountryRegionCurrency>> GetCurrencyCode(string currencyCode);
	}
}

/*<Codenesium>
    <Hash>6b9b6f4e3dcf230486c2939674fab718</Hash>
</Codenesium>*/