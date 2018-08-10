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
    <Hash>d32b1f918c1f2862215110693e2548a9</Hash>
</Codenesium>*/