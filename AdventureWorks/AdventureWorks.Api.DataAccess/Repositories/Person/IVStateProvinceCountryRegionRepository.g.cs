using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IVStateProvinceCountryRegionRepository
	{
		Task<VStateProvinceCountryRegion> Get(int stateProvinceID);

		Task<List<VStateProvinceCountryRegion>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>180b9fe0ea00f9bb6ce92028939f9d31</Hash>
</Codenesium>*/