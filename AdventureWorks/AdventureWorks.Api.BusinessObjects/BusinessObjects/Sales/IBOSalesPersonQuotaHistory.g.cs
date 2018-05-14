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
		Task<CreateResponse<POCOSalesPersonQuotaHistory>> Create(
			ApiSalesPersonQuotaHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiSalesPersonQuotaHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOSalesPersonQuotaHistory Get(int businessEntityID);

		List<POCOSalesPersonQuotaHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9a8ac38a93dcce24b5235554a5c7571c</Hash>
</Codenesium>*/