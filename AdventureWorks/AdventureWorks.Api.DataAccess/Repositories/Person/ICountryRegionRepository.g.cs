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
    <Hash>7a90448da28da0372e84def5ca892ca6</Hash>
</Codenesium>*/