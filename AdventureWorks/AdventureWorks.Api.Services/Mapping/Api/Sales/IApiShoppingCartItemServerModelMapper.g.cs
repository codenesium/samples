using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShoppingCartItemServerModelMapper
	{
		ApiShoppingCartItemServerResponseModel MapServerRequestToResponse(
			int shoppingCartItemID,
			ApiShoppingCartItemServerRequestModel request);

		ApiShoppingCartItemServerRequestModel MapServerResponseToRequest(
			ApiShoppingCartItemServerResponseModel response);

		ApiShoppingCartItemClientRequestModel MapServerResponseToClientRequest(
			ApiShoppingCartItemServerResponseModel response);

		JsonPatchDocument<ApiShoppingCartItemServerRequestModel> CreatePatch(ApiShoppingCartItemServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c69e674fc36877905c5579d07fbb3051</Hash>
</Codenesium>*/