using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ICurrencyRateRepository
        {
                Task<CurrencyRate> Create(CurrencyRate item);

                Task Update(CurrencyRate item);

                Task Delete(int currencyRateID);

                Task<CurrencyRate> Get(int currencyRateID);

                Task<List<CurrencyRate>> All(int limit = int.MaxValue, int offset = 0);

                Task<CurrencyRate> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode);

                Task<List<SalesOrderHeader>> SalesOrderHeaders(int currencyRateID, int limit = int.MaxValue, int offset = 0);

                Task<Currency> GetCurrency(string fromCurrencyCode);
        }
}

/*<Codenesium>
    <Hash>ba45e6fb9cd7b153c5742917b4482edd</Hash>
</Codenesium>*/