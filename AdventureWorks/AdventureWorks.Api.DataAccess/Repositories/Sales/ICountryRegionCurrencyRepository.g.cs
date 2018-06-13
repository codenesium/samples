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

                Task<List<CountryRegionCurrency>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<CountryRegionCurrency>> GetCurrencyCode(string currencyCode);
        }
}

/*<Codenesium>
    <Hash>a588884a51fa4226cbec53e66aef7731</Hash>
</Codenesium>*/