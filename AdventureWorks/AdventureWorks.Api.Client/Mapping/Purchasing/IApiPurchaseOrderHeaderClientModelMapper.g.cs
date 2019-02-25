using AdventureWorksNS.Api.Contracts;
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
    <Hash>95a5f2d546ae6a5e7340e0ba5bd5f69d</Hash>
</Codenesium>*/