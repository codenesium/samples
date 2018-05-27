using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLShoppingCartItemMapper
	{
		DTOShoppingCartItem MapModelToDTO(
			int shoppingCartItemID,
			ApiShoppingCartItemRequestModel model);

		ApiShoppingCartItemResponseModel MapDTOToModel(
			DTOShoppingCartItem dtoShoppingCartItem);

		List<ApiShoppingCartItemResponseModel> MapDTOToModel(
			List<DTOShoppingCartItem> dtos);
	}
}

/*<Codenesium>
    <Hash>1d2c431042e12fdffc28c23f41c8b09c</Hash>
</Codenesium>*/