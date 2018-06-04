using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonQuotaHistoryRepository
	{
		Task<SalesPersonQuotaHistory> Create(SalesPersonQuotaHistory item);

		Task Update(SalesPersonQuotaHistory item);

		Task Delete(int businessEntityID);

		Task<SalesPersonQuotaHistory> Get(int businessEntityID);

		Task<List<SalesPersonQuotaHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2e7d28599d7414bb55d586735b64f627</Hash>
</Codenesium>*/