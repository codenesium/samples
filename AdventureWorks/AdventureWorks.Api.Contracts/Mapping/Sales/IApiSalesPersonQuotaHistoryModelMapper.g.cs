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
    <Hash>9fb5857bded8356380fe44ea269fec52</Hash>
</Codenesium>*/