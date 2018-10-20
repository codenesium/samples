using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ICountryRegionRepository
	{
		Task<CountryRegion> Create(CountryRegion item);

		Task Update(CountryRegion item);

		Task Delete(string countryRegionCode);

		Task<CountryRegion> Get(string countryRegionCode);

		Task<List<CountryRegion>> All(int limit = int.MaxValue, int offset = 0);

		Task<CountryRegion> ByName(string name);

		Task<List<StateProvince>> StateProvincesByCountryRegionCode(string countryRegionCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8a0f6a4b2f35d8c6b61ef082202fb7f7</Hash>
</Codenesium>*/