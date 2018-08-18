using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductCostHistoryModelMapper
	{
		ApiProductCostHistoryResponseModel MapRequestToResponse(
			int productID,
			ApiProductCostHistoryRequestModel request);

		ApiProductCostHistoryRequestModel MapResponseToRequest(
			ApiProductCostHistoryResponseModel response);

		JsonPatchDocument<ApiProductCostHistoryRequestModel> CreatePatch(ApiProductCostHistoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bc0ac92193e934e108ffc0fbf88e4eae</Hash>
</Codenesium>*/