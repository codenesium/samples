using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPurchaseOrderHeaderServerModelMapper
	{
		ApiPurchaseOrderHeaderServerResponseModel MapServerRequestToResponse(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderServerRequestModel request);

		ApiPurchaseOrderHeaderServerRequestModel MapServerResponseToRequest(
			ApiPurchaseOrderHeaderServerResponseModel response);

		ApiPurchaseOrderHeaderClientRequestModel MapServerResponseToClientRequest(
			ApiPurchaseOrderHeaderServerResponseModel response);

		JsonPatchDocument<ApiPurchaseOrderHeaderServerRequestModel> CreatePatch(ApiPurchaseOrderHeaderServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b827e68deaa8a11e31a06d8c796e3395</Hash>
</Codenesium>*/