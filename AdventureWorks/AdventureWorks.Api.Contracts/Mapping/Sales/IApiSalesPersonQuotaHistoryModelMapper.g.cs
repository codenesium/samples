using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSalesPersonQuotaHistoryModelMapper
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
    <Hash>948ed7c5d64a5c58ff8204bde38a432b</Hash>
</Codenesium>*/