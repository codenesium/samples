using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiPurchaseOrderDetailModelMapper
	{
		ApiPurchaseOrderDetailResponseModel MapRequestToResponse(
			int purchaseOrderID,
			ApiPurchaseOrderDetailRequestModel request);

		ApiPurchaseOrderDetailRequestModel MapResponseToRequest(
			ApiPurchaseOrderDetailResponseModel response);

		JsonPatchDocument<ApiPurchaseOrderDetailRequestModel> CreatePatch(ApiPurchaseOrderDetailRequestModel model);
	}
}

/*<Codenesium>
    <Hash>13915c3251182affb168483523f1b85e</Hash>
</Codenesium>*/