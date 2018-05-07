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
		Task<CreateResponse<int>> Create(
			SalesTerritoryModel model);

		Task<ActionResponse> Update(int territoryID,
		                            SalesTerritoryModel model);

		Task<ActionResponse> Delete(int territoryID);

		POCOSalesTerritory Get(int territoryID);

		List<POCOSalesTerritory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>06153b199572b102beff257198651aa6</Hash>
</Codenesium>*/