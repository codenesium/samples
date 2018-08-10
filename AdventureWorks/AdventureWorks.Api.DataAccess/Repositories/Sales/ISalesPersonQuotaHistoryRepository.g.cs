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
    <Hash>dc61d32b842f78cc61785141c8afe581</Hash>
</Codenesium>*/