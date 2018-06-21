using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>be51c337ca842108dd2a1eaeb92ae73c</Hash>
</Codenesium>*/