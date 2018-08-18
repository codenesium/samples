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
    <Hash>5f80af8bbbbbaa817e142337f400346c</Hash>
</Codenesium>*/