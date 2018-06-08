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

                Task<List<CurrencyRate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<CurrencyRate> GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode);
        }
}

/*<Codenesium>
    <Hash>a10f6cb897e2360e625569a0d66ca0e3</Hash>
</Codenesium>*/