using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryRepository
	{
		Task<POCOSalesTerritory> Create(ApiSalesTerritoryModel model);

		Task Update(int territoryID,
		            ApiSalesTerritoryModel model);

		Task Delete(int territoryID);

		Task<POCOSalesTerritory> Get(int territoryID);

		Task<List<POCOSalesTerritory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOSalesTerritory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>7b5c1417df745d54b1355a8e6f27cfa8</Hash>
</Codenesium>*/