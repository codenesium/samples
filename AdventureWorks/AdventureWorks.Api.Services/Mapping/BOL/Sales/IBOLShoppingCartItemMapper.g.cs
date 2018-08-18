using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLShoppingCartItemMapper
	{
		BOShoppingCartItem MapModelToBO(
			int shoppingCartItemID,
			ApiShoppingCartItemRequestModel model);

		ApiShoppingCartItemResponseModel MapBOToModel(
			BOShoppingCartItem boShoppingCartItem);

		List<ApiShoppingCartItemResponseModel> MapBOToModel(
			List<BOShoppingCartItem> items);
	}
}

/*<Codenesium>
    <Hash>a6f70523715851437ede8cd5831051af</Hash>
</Codenesium>*/