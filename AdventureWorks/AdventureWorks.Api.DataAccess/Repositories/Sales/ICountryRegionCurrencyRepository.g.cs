using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ICountryRegionCurrencyRepository
	{
		Task<CountryRegionCurrency> Create(CountryRegionCurrency item);

		Task Update(CountryRegionCurrency item);

		Task Delete(string countryRegionCode);

		Task<CountryRegionCurrency> Get(string countryRegionCode);

		Task<List<CountryRegionCurrency>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<CountryRegionCurrency>> ByCurrencyCode(string currencyCode);

		Task<Currency> GetCurrency(string currencyCode);
	}
}

/*<Codenesium>
    <Hash>1cd0bc96a2e2184b05d0856a24d789b9</Hash>
</Codenesium>*/