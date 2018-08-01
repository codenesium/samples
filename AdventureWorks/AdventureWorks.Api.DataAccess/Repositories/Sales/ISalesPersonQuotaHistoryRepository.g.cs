using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonQuotaHistoryRepository
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
    <Hash>17d5cd24c0cb5a3acbba3e3b25cfc9f1</Hash>
</Codenesium>*/