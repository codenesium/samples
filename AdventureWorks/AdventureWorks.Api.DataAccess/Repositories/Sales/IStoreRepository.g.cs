using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IStoreRepository
	{
		Task<Store> Create(Store item);

		Task Update(Store item);

		Task Delete(int businessEntityID);

		Task<Store> Get(int businessEntityID);

		Task<List<Store>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Store>> BySalesPersonID(int? salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<Store>> ByDemographic(string demographic, int limit = int.MaxValue, int offset = 0);

		Task<List<Customer>> Customers(int storeID, int limit = int.MaxValue, int offset = 0);

		Task<SalesPerson> GetSalesPerson(int? salesPersonID);
	}
}

/*<Codenesium>
    <Hash>b6e394e934a3c72fe9ed5d0f6bbab153</Hash>
</Codenesium>*/