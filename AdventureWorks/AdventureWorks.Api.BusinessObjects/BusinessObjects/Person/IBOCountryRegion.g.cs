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
		Task<CreateResponse<POCOCountryRegion>> Create(
			ApiCountryRegionModel model);

		Task<ActionResponse> Update(string countryRegionCode,
		                            ApiCountryRegionModel model);

		Task<ActionResponse> Delete(string countryRegionCode);

		POCOCountryRegion Get(string countryRegionCode);

		List<POCOCountryRegion> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCountryRegion GetName(string name);
	}
}

/*<Codenesium>
    <Hash>447d95d9facf513f32623b7b6952e922</Hash>
</Codenesium>*/