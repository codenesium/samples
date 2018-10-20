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

		Task<List<SalesOrderHeader>> SalesOrderHeadersBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesPersonQuotaHistory>> SalesPersonQuotaHistoriesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesTerritoryHistory>> SalesTerritoryHistoriesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<Store>> StoresBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<SalesTerritory> SalesTerritoryByTerritoryID(int? territoryID);
	}
}

/*<Codenesium>
    <Hash>a97e87b9a267451ca7449b35341d20a6</Hash>
</Codenesium>*/