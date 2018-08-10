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
    <Hash>52bba0d220c6fb5dbc762affadd66b06</Hash>
</Codenesium>*/