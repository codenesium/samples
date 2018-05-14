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

		POCOSalesTerritory Get(int territoryID);

		List<POCOSalesTerritory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOSalesTerritory GetName(string name);
	}
}

/*<Codenesium>
    <Hash>df06c13968fbde30bb59ee4626f93a23</Hash>
</Codenesium>*/