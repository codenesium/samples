using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesPersonQuotaHistoryService
	{
		Task<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Create(
			ApiSalesPersonQuotaHistoryRequestModel model);

		Task<UpdateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Update(int businessEntityID,
		                                                                      ApiSalesPersonQuotaHistoryRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiSalesPersonQuotaHistoryResponseModel> Get(int businessEntityID);

		Task<List<ApiSalesPersonQuotaHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>64562d3120f71b4254c200765e876d86</Hash>
</Codenesium>*/