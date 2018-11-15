using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiShoppingCartItemModelMapper
	{
		ApiShoppingCartItemClientResponseModel MapClientRequestToResponse(
			int shoppingCartItemID,
			ApiShoppingCartItemClientRequestModel request);

		ApiShoppingCartItemClientRequestModel MapClientResponseToRequest(
			ApiShoppingCartItemClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>3e738576121d164cfd1ee720acd44dff</Hash>
</Codenesium>*/