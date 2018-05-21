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

		Task<POCOCountryRegion> Get(string countryRegionCode);

		Task<List<POCOCountryRegion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCountryRegion> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>dc947c5ea476f8bed8565749c2557ecc</Hash>
</Codenesium>*/