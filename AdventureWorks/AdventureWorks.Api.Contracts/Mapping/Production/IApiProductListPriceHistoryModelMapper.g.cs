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
    <Hash>4671e6af3c26e13f65dc6f58ac29a356</Hash>
</Codenesium>*/