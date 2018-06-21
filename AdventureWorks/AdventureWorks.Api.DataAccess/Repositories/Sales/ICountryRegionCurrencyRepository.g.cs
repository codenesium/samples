using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ICountryRegionCurrencyRepository
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
    <Hash>5f65ee040e64fef1d397d2ad9aeae356</Hash>
</Codenesium>*/