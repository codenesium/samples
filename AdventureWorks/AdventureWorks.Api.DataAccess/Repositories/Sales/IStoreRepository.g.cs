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

		Task<SalesPerson> SalesPersonBySalesPersonID(int? salesPersonID);
	}
}

/*<Codenesium>
    <Hash>621231c6d7a57c46dfbd8cc39b33606c</Hash>
</Codenesium>*/