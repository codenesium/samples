using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiShoppingCartItemModelMapper
	{
		ApiShoppingCartItemResponseModel MapRequestToResponse(
			int shoppingCartItemID,
			ApiShoppingCartItemRequestModel request);

		ApiShoppingCartItemRequestModel MapResponseToRequest(
			ApiShoppingCartItemResponseModel response);

		JsonPatchDocument<ApiShoppingCartItemRequestModel> CreatePatch(ApiShoppingCartItemRequestModel model);
	}
}

/*<Codenesium>
    <Hash>116dc5f5c216a81594eb7ae438713c12</Hash>
</Codenesium>*/