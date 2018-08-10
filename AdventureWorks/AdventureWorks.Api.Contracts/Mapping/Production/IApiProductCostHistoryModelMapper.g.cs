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
    <Hash>d110f44dabab486535fe735466bc7c1a</Hash>
</Codenesium>*/