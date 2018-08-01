using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiShoppingCartItemModelMapper
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
    <Hash>b47e77fabdc0511301de0c6fb8093519</Hash>
</Codenesium>*/