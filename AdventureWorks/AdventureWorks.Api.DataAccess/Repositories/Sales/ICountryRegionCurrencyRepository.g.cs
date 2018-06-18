using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>7ea90056048f1a2ee1a1c945b3dd24fc</Hash>
</Codenesium>*/