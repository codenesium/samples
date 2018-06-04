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
			List<BOShoppingCartItem> bos);
	}
}

/*<Codenesium>
    <Hash>b9942ab60db067c9fed5321de14ae0ed</Hash>
</Codenesium>*/