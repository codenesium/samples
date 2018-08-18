using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ISalesPersonQuotaHistoryRepository
	{
		Task<SalesPersonQuotaHistory> Create(SalesPersonQuotaHistory item);

		Task Update(SalesPersonQuotaHistory item);

		Task Delete(int businessEntityID);

		Task<SalesPersonQuotaHistory> Get(int businessEntityID);

		Task<List<SalesPersonQuotaHistory>> All(int limit = int.MaxValue, int offset = 0);

		Task<SalesPerson> GetSalesPerson(int businessEntityID);
	}
}

/*<Codenesium>
    <Hash>e6324334eacba815b1bf448256ba2e61</Hash>
</Codenesium>*/