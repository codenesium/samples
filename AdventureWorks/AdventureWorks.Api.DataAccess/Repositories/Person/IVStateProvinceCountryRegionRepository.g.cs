using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IVStateProvinceCountryRegionRepository
	{
		Task<VStateProvinceCountryRegion> Create(VStateProvinceCountryRegion item);

		Task Update(VStateProvinceCountryRegion item);

		Task Delete(int stateProvinceID);

		Task<VStateProvinceCountryRegion> Get(int stateProvinceID);

		Task<List<VStateProvinceCountryRegion>> All(int limit = int.MaxValue, int offset = 0);

		Task<VStateProvinceCountryRegion> ByStateProvinceIDCountryRegionCode(int stateProvinceID, string countryRegionCode);
	}
}

/*<Codenesium>
    <Hash>45e46c21f084d6cdc11820f8efcfe988</Hash>
</Codenesium>*/