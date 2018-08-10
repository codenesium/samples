using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALShoppingCartItemMapper
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
    <Hash>5c4e0ba28be9f335bf5031d0897e081d</Hash>
</Codenesium>*/