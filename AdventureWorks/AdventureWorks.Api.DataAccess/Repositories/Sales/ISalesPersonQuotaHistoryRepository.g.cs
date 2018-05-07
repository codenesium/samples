using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonQuotaHistoryRepository
	{
		int Create(SalesPersonQuotaHistoryModel model);

		void Update(int businessEntityID,
		            SalesPersonQuotaHistoryModel model);

		void Delete(int businessEntityID);

		POCOSalesPersonQuotaHistory Get(int businessEntityID);

		List<POCOSalesPersonQuotaHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>88cd287fa3e0a3aa00ae6f88ed4e8a7a</Hash>
</Codenesium>*/