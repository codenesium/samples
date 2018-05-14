using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesPersonQuotaHistoryRepository
	{
		POCOSalesPersonQuotaHistory Create(ApiSalesPersonQuotaHistoryModel model);

		void Update(int businessEntityID,
		            ApiSalesPersonQuotaHistoryModel model);

		void Delete(int businessEntityID);

		POCOSalesPersonQuotaHistory Get(int businessEntityID);

		List<POCOSalesPersonQuotaHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e3ce9f1bb6770c1abf15ef4cc7b1cd37</Hash>
</Codenesium>*/