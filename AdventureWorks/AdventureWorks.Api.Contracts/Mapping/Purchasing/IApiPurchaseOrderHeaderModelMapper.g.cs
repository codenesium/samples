using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiPurchaseOrderHeaderModelMapper
	{
		ApiPurchaseOrderHeaderResponseModel MapRequestToResponse(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderRequestModel request);

		ApiPurchaseOrderHeaderRequestModel MapResponseToRequest(
			ApiPurchaseOrderHeaderResponseModel response);

		JsonPatchDocument<ApiPurchaseOrderHeaderRequestModel> CreatePatch(ApiPurchaseOrderHeaderRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4cb3f55474c291308dfc2c6d02f7c5eb</Hash>
</Codenesium>*/