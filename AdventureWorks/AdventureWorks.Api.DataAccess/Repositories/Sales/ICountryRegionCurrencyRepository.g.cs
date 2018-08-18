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

		Task<List<CountryRegionCurrency>> ByCurrencyCode(string currencyCode, int limit = int.MaxValue, int offset = 0);

		Task<Currency> GetCurrency(string currencyCode);
	}
}

/*<Codenesium>
    <Hash>f692a01545867101a9e263a1177984f1</Hash>
</Codenesium>*/