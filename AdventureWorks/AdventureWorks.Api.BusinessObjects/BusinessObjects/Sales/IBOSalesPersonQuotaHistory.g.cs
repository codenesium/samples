using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesPersonQuotaHistory
	{
		Task<CreateResponse<int>> Create(
			SalesPersonQuotaHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            SalesPersonQuotaHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOSalesPersonQuotaHistory Get(int businessEntityID);

		List<POCOSalesPersonQuotaHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2650c5136fe4daff0942a1bb94d923f0</Hash>
</Codenesium>*/