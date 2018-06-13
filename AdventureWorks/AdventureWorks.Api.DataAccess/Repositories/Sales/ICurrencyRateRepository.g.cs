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

                Task<List<CurrencyRate>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<CurrencyRate> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode);

                Task<List<SalesOrderHeader>> SalesOrderHeaders(int currencyRateID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>16c4aec145a4993bf401f3285f32c33d</Hash>
</Codenesium>*/