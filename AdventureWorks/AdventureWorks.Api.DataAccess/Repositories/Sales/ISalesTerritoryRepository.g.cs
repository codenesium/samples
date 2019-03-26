using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISalesTerritoryRepository
	{
		Task<SalesTerritory> Create(SalesTerritory item);

		Task Update(SalesTerritory item);

		Task Delete(int territoryID);

		Task<SalesTerritory> Get(int territoryID);

		Task<List<SalesTerritory>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<SalesTerritory> ByName(string name);

		Task<SalesTerritory> ByRowguid(Guid rowguid);

		Task<List<Customer>> CustomersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesOrderHeader>> SalesOrderHeadersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesPerson>> SalesPersonsByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>79a7b8d66a190ce4d697beaa61717b93</Hash>
</Codenesium>*/