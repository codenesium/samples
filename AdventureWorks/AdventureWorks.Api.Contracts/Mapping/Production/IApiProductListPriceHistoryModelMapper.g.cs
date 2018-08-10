using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiProductListPriceHistoryModelMapper
	{
		ApiProductListPriceHistoryResponseModel MapRequestToResponse(
			int productID,
			ApiProductListPriceHistoryRequestModel request);

		ApiProductListPriceHistoryRequestModel MapResponseToRequest(
			ApiProductListPriceHistoryResponseModel response);

		JsonPatchDocument<ApiProductListPriceHistoryRequestModel> CreatePatch(ApiProductListPriceHistoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2a983de864e67a04e636d4fd5e6f4b42</Hash>
</Codenesium>*/