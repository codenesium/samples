using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ICurrencyRepository
	{
		Task<Currency> Create(Currency item);

		Task Update(Currency item);

		Task Delete(string currencyCode);

		Task<Currency> Get(string currencyCode);

		Task<List<Currency>> All(int limit = int.MaxValue, int offset = 0);

		Task<Currency> ByName(string name);

		Task<List<CountryRegionCurrency>> CountryRegionCurrencies(string currencyCode, int limit = int.MaxValue, int offset = 0);

		Task<List<CurrencyRate>> CurrencyRates(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f6c933b1b350a73728ae41efeb6fbf19</Hash>
</Codenesium>*/