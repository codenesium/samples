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

		Task<List<SalesOrderHeader>> SalesOrderHeaders(int customerID, int limit = int.MaxValue, int offset = 0);

		Task<Store> GetStore(int? storeID);

		Task<SalesTerritory> GetSalesTerritory(int? territoryID);
	}
}

/*<Codenesium>
    <Hash>d79c8792d9ecbe6d40accbf2cf314618</Hash>
</Codenesium>*/