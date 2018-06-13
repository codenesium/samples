using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ICurrencyRepository
        {
                Task<Currency> Create(Currency item);

                Task Update(Currency item);

                Task Delete(string currencyCode);

                Task<Currency> Get(string currencyCode);

                Task<List<Currency>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Currency> GetName(string name);

                Task<List<CountryRegionCurrency>> CountryRegionCurrencies(string currencyCode, int limit = int.MaxValue, int offset = 0);
                Task<List<CurrencyRate>> CurrencyRates(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>170cc8244586bce4d99d0e53d9bce8de</Hash>
</Codenesium>*/