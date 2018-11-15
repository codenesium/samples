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
			ApiShoppingCartItemServerRequestModel model);

		ApiShoppingCartItemServerResponseModel MapBOToModel(
			BOShoppingCartItem boShoppingCartItem);

		List<ApiShoppingCartItemServerResponseModel> MapBOToModel(
			List<BOShoppingCartItem> items);
	}
}

/*<Codenesium>
    <Hash>5065dd69647a1393de2ffb8d3ec31403</Hash>
</Codenesium>*/