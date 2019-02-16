using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALShoppingCartItemMapper
	{
		ShoppingCartItem MapModelToBO(
			int shoppingCartItemID,
			ApiShoppingCartItemServerRequestModel model);

		ApiShoppingCartItemServerResponseModel MapBOToModel(
			ShoppingCartItem item);

		List<ApiShoppingCartItemServerResponseModel> MapBOToModel(
			List<ShoppingCartItem> items);
	}
}

/*<Codenesium>
    <Hash>0f60e5107dc14283d32a60fde6d6d4ec</Hash>
</Codenesium>*/