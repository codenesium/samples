using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStoreRepository
	{
		Task<Store> Create(Store item);

		Task Update(Store item);

		Task Delete(int businessEntityID);

		Task<Store> Get(int businessEntityID);

		Task<List<Store>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Store>> BySalesPersonID(int? salesPersonID);

		Task<List<Store>> ByDemographic(string demographic);

		Task<List<Customer>> Customers(int storeID, int limit = int.MaxValue, int offset = 0);

		Task<SalesPerson> GetSalesPerson(int? salesPersonID);
	}
}

/*<Codenesium>
    <Hash>4dae3172f8eec40306b4d9b2ab3b9f2b</Hash>
</Codenesium>*/