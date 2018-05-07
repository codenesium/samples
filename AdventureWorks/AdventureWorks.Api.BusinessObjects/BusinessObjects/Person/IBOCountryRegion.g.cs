using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCountryRegion
	{
		Task<CreateResponse<string>> Create(
			CountryRegionModel model);

		Task<ActionResponse> Update(string countryRegionCode,
		                            CountryRegionModel model);

		Task<ActionResponse> Delete(string countryRegionCode);

		POCOCountryRegion Get(string countryRegionCode);

		List<POCOCountryRegion> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3b0331e44d10f42318e52eede3a4ba7b</Hash>
</Codenesium>*/