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

		Task<List<CurrencyRate>> CurrencyRates(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>353f72a55bfa0b4659d611d17f681012</Hash>
</Codenesium>*/