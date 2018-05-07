using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryRepository
	{
		int Create(SalesTerritoryModel model);

		void Update(int territoryID,
		            SalesTerritoryModel model);

		void Delete(int territoryID);

		POCOSalesTerritory Get(int territoryID);

		List<POCOSalesTerritory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ce25a3c22a72fc22afdec3343609b7e7</Hash>
</Codenesium>*/