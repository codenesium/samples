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

		Task<SalesPerson> SalesPersonByBusinessEntityID(int businessEntityID);
	}
}

/*<Codenesium>
    <Hash>00bb029da4a05587b3237829f68f84cb</Hash>
</Codenesium>*/