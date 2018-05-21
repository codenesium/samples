using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesTerritory
	{
		Task<CreateResponse<POCOSalesTerritory>> Create(
			ApiSalesTerritoryModel model);

		Task<ActionResponse> Update(int territoryID,
		                            ApiSalesTerritoryModel model);

		Task<ActionResponse> Delete(int territoryID);

		Task<POCOSalesTerritory> Get(int territoryID);

		Task<List<POCOSalesTerritory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOSalesTerritory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>e31e65d128a827bad3730b9999601342</Hash>
</Codenesium>*/