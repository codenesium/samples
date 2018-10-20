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

		Task<List<CurrencyRate>> CurrencyRatesByFromCurrencyCode(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0);

		Task<List<CurrencyRate>> CurrencyRatesByToCurrencyCode(string toCurrencyCode, int limit = int.MaxValue, int offset = 0);

		Task<List<Currency>> ByCountryRegionCode(int countryRegionCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1721f14f912a7b908b159c3731b61c16</Hash>
</Codenesium>*/