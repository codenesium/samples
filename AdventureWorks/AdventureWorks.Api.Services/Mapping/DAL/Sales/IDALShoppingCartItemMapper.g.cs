using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>8e72d899a70b96414cc0a05e88ad7d5b</Hash>
</Codenesium>*/