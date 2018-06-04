using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ISalesPersonQuotaHistoryService
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
    <Hash>6ff066edc2d81e85122ee347aa2735fb</Hash>
</Codenesium>*/