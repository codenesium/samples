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
    <Hash>5fbe7476456e41eb4d3d2716d5f8462a</Hash>
</Codenesium>*/