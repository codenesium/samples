using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiPurchaseOrderHeaderModelMapper
	{
		ApiPurchaseOrderHeaderClientResponseModel MapClientRequestToResponse(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderClientRequestModel request);

		ApiPurchaseOrderHeaderClientRequestModel MapClientResponseToRequest(
			ApiPurchaseOrderHeaderClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>f880c2314132d2ef535660f3617b6c63</Hash>
</Codenesium>*/