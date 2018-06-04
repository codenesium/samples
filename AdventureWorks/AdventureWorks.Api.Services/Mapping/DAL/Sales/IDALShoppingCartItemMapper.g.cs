using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALShoppingCartItemMapper
	{
		ShoppingCartItem MapBOToEF(
			BOShoppingCartItem bo);

		BOShoppingCartItem MapEFToBO(
			ShoppingCartItem efShoppingCartItem);

		List<BOShoppingCartItem> MapEFToBO(
			List<ShoppingCartItem> records);
	}
}

/*<Codenesium>
    <Hash>fe3132344966c176e4453e31d8001f6b</Hash>
</Codenesium>*/