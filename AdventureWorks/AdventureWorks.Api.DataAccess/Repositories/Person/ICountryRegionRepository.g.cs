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

                Task<List<CountryRegion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<CountryRegion> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>076246da80aaae9b3096501d443dc5d0</Hash>
</Codenesium>*/