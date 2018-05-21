using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonQuotaHistoryRepository
	{
		Task<POCOSalesPersonQuotaHistory> Create(ApiSalesPersonQuotaHistoryModel model);

		Task Update(int businessEntityID,
		            ApiSalesPersonQuotaHistoryModel model);

		Task Delete(int businessEntityID);

		Task<POCOSalesPersonQuotaHistory> Get(int businessEntityID);

		Task<List<POCOSalesPersonQuotaHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>eceea17fe5fae415fc8108260ecfc181</Hash>
</Codenesium>*/