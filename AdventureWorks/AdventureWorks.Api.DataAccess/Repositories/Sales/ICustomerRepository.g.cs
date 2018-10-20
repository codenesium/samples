using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ICustomerRepository
	{
		Task<Customer> Create(Customer item);

		Task Update(Customer item);

		Task Delete(int customerID);

		Task<Customer> Get(int customerID);

		Task<List<Customer>> All(int limit = int.MaxValue, int offset = 0);

		Task<Customer> ByAccountNumber(string accountNumber);

		Task<List<Customer>> ByTerritoryID(int? territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<SalesOrderHeader>> SalesOrderHeadersByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0);

		Task<Store> StoreByStoreID(int? storeID);

		Task<SalesTerritory> SalesTerritoryByTerritoryID(int? territoryID);
	}
}

/*<Codenesium>
    <Hash>0eaf579d6e034992c3b5f14f14feb36c</Hash>
</Codenesium>*/