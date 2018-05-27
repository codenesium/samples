using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALShoppingCartItemMapper
	{
		void MapDTOToEF(
			int shoppingCartItemID,
			DTOShoppingCartItem dto,
			ShoppingCartItem efShoppingCartItem);

		DTOShoppingCartItem MapEFToDTO(
			ShoppingCartItem efShoppingCartItem);
	}
}

/*<Codenesium>
    <Hash>2405312459779a65fe2ab2e6fad82398</Hash>
</Codenesium>*/