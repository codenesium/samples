using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryRepository
	{
		POCOSalesTerritory Create(ApiSalesTerritoryModel model);

		void Update(int territoryID,
		            ApiSalesTerritoryModel model);

		void Delete(int territoryID);

		POCOSalesTerritory Get(int territoryID);

		List<POCOSalesTerritory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOSalesTerritory GetName(string name);
	}
}

/*<Codenesium>
    <Hash>10f062d5a6862df7fdb693fc3c173590</Hash>
</Codenesium>*/