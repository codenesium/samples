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
		Task<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Create(
			ApiSalesPersonQuotaHistoryRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiSalesPersonQuotaHistoryRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiSalesPersonQuotaHistoryResponseModel> Get(int businessEntityID);

		Task<List<ApiSalesPersonQuotaHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3b1c2c13956a225e2074cef8ae5afe46</Hash>
</Codenesium>*/