using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ICountryRegionRepository
        {
                Task<CountryRegion> Create(CountryRegion item);

                Task Update(CountryRegion item);

                Task Delete(string countryRegionCode);

                Task<CountryRegion> Get(string countryRegionCode);

                Task<List<CountryRegion>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<CountryRegion> GetName(string name);

                Task<List<StateProvince>> StateProvinces(string countryRegionCode, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e5d8080958b16d3fc69e55f4f70efa5d</Hash>
</Codenesium>*/