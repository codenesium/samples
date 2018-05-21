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

		Task<POCOSalesPersonQuotaHistory> Get(int businessEntityID);

		Task<List<POCOSalesPersonQuotaHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0c5678e5a6a48b767b2b4e12b68a589a</Hash>
</Codenesium>*/