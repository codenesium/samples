using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLShoppingCartItemMapper
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
    <Hash>88f51e3f89f321e1a6145d5f65349020</Hash>
</Codenesium>*/