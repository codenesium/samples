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

		Task<List<SalesPerson>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<SalesPerson> ByRowguid(Guid rowguid);

		Task<List<SalesOrderHeader>> SalesOrderHeadersBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<Store>> StoresBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<SalesTerritory> SalesTerritoryByTerritoryID(int? territoryID);
	}
}

/*<Codenesium>
    <Hash>26e23ea340917ff2f07e3f2bfb8a57c5</Hash>
</Codenesium>*/