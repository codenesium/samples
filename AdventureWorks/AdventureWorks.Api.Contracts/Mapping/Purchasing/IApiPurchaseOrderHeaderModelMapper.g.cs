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
    <Hash>ee5eb10933ce14153f79528f4d918414</Hash>
</Codenesium>*/