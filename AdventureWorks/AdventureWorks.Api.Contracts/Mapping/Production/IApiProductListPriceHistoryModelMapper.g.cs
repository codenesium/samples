using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiProductListPriceHistoryModelMapper
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
    <Hash>af7e3e6b2d830eb025760ace31bee35c</Hash>
</Codenesium>*/