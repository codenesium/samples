using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ICountryRegionRepository
        {
                Task<CountryRegion> Create(CountryRegion item);

                Task Update(CountryRegion item);

                Task Delete(string countryRegionCode);

                Task<CountryRegion> Get(string countryRegionCode);

                Task<List<CountryRegion>> All(int limit = int.MaxValue, int offset = 0);

                Task<CountryRegion> ByName(string name);

                Task<List<StateProvince>> StateProvinces(string countryRegionCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d2b4b1dbcb84c2e7c3972864f743f20b</Hash>
</Codenesium>*/