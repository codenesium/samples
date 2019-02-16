using AdventureWorksNS.Api.Contracts;
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
    <Hash>c292453ed24bd9f5dd0bdc9539ca00f7</Hash>
</Codenesium>*/