using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSalesPersonQuotaHistoryModelMapper
	{
		ApiSalesPersonQuotaHistoryResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel request);

		ApiSalesPersonQuotaHistoryRequestModel MapResponseToRequest(
			ApiSalesPersonQuotaHistoryResponseModel response);

		JsonPatchDocument<ApiSalesPersonQuotaHistoryRequestModel> CreatePatch(ApiSalesPersonQuotaHistoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>975b0f190189780506554a11df9fa65c</Hash>
</Codenesium>*/