using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiPurchaseOrderHeaderModelMapper
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
    <Hash>9cfad08b60e2279f114f840848d98a91</Hash>
</Codenesium>*/