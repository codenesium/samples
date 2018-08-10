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

		Task<SalesPerson> GetSalesPerson(int businessEntityID);

		Task<SalesTerritory> GetSalesTerritory(int territoryID);
	}
}

/*<Codenesium>
    <Hash>b51cb4cb09d49067f32149748a041e7a</Hash>
</Codenesium>*/