using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionRepository
	{
		Task<POCOCountryRegion> Create(ApiCountryRegionModel model);

		Task Update(string countryRegionCode,
		            ApiCountryRegionModel model);

		Task Delete(string countryRegionCode);

		Task<POCOCountryRegion> Get(string countryRegionCode);

		Task<List<POCOCountryRegion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCountryRegion> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>df76e27e9ec79e69109e3f0c645a2d30</Hash>
</Codenesium>*/