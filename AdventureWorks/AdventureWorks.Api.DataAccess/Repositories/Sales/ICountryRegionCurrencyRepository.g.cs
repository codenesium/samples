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

                Task<List<CountryRegionCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<CountryRegionCurrency>> GetCurrencyCode(string currencyCode);
        }
}

/*<Codenesium>
    <Hash>a3dd080cdfecb5abd91d53730d207272</Hash>
</Codenesium>*/