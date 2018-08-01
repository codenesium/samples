using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiPurchaseOrderDetailModelMapper
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
    <Hash>b022b103dff2b6e0adc69fe1c8deda08</Hash>
</Codenesium>*/