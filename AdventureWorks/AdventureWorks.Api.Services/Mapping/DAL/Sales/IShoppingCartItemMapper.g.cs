using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALShoppingCartItemMapper
	{
		ShoppingCartItem MapModelToEntity(
			int shoppingCartItemID,
			ApiShoppingCartItemServerRequestModel model);

		ApiShoppingCartItemServerResponseModel MapEntityToModel(
			ShoppingCartItem item);

		List<ApiShoppingCartItemServerResponseModel> MapEntityToModel(
			List<ShoppingCartItem> items);
	}
}

/*<Codenesium>
    <Hash>84d235a4e082f8fd76e8a1f15dc2575b</Hash>
</Codenesium>*/