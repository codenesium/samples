using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISalesPersonRepository
	{
		Task<SalesPerson> Create(SalesPerson item);

		Task Update(SalesPerson item);

		Task Delete(int businessEntityID);

		Task<SalesPerson> Get(int businessEntityID);

		Task<List<SalesPerson>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<SalesOrderHeader>> SalesOrderHeaders(int salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesPersonQuotaHistory>> SalesPersonQuotaHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesTerritoryHistory>> SalesTerritoryHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<Store>> Stores(int salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<SalesTerritory> SalesTerritoryByTerritoryID(int? territoryID);
	}
}

/*<Codenesium>
    <Hash>ef2425acd76d1d4ef4debd76206913ab</Hash>
</Codenesium>*/