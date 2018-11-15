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

		Task<Store> ByRowguid(Guid rowguid);

		Task<List<Store>> BySalesPersonID(int? salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<Store>> ByDemographic(string demographic, int limit = int.MaxValue, int offset = 0);

		Task<List<Customer>> CustomersByStoreID(int storeID, int limit = int.MaxValue, int offset = 0);

		Task<SalesPerson> SalesPersonBySalesPersonID(int? salesPersonID);
	}
}

/*<Codenesium>
    <Hash>8f92844ffe6812eadb020d5e2432e8d6</Hash>
</Codenesium>*/