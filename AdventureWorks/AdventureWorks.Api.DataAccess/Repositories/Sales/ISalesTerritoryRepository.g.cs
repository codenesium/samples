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

		Task<List<SalesTerritory>> All(int limit = int.MaxValue, int offset = 0);

		Task<SalesTerritory> ByName(string name);

		Task<List<Customer>> Customers(int territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesOrderHeader>> SalesOrderHeaders(int territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesPerson>> SalesPersons(int territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesTerritoryHistory>> SalesTerritoryHistories(int territoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3b5a2c943c8c165058748075bbc06fac</Hash>
</Codenesium>*/