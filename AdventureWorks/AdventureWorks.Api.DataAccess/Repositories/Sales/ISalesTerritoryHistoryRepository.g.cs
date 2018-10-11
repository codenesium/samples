using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISalesTerritoryHistoryRepository
	{
		Task<SalesTerritoryHistory> Create(SalesTerritoryHistory item);

		Task Update(SalesTerritoryHistory item);

		Task Delete(int businessEntityID);

		Task<SalesTerritoryHistory> Get(int businessEntityID);

		Task<List<SalesTerritoryHistory>> All(int limit = int.MaxValue, int offset = 0);

		Task<SalesPerson> SalesPersonByBusinessEntityID(int businessEntityID);

		Task<SalesTerritory> SalesTerritoryByTerritoryID(int territoryID);
	}
}

/*<Codenesium>
    <Hash>38c45ade813ff2700eeaf1ab8b6306a8</Hash>
</Codenesium>*/