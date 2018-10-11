using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IVStateProvinceCountryRegionService
	{
		Task<ApiVStateProvinceCountryRegionResponseModel> Get(int stateProvinceID);

		Task<List<ApiVStateProvinceCountryRegionResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>27922a4dc06e530782afb64e85e70bca</Hash>
</Codenesium>*/