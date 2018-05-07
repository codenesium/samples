using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShoppingCartItemRepository
	{
		int Create(ShoppingCartItemModel model);

		void Update(int shoppingCartItemID,
		            ShoppingCartItemModel model);

		void Delete(int shoppingCartItemID);

		POCOShoppingCartItem Get(int shoppingCartItemID);

		List<POCOShoppingCartItem> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>aee3fb4c85f870e77a3928b4a6a15273</Hash>
</Codenesium>*/