using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShoppingCartItemRepository
	{
		POCOShoppingCartItem Create(ApiShoppingCartItemModel model);

		void Update(int shoppingCartItemID,
		            ApiShoppingCartItemModel model);

		void Delete(int shoppingCartItemID);

		POCOShoppingCartItem Get(int shoppingCartItemID);

		List<POCOShoppingCartItem> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShoppingCartItem> GetShoppingCartIDProductID(string shoppingCartID,int productID);
	}
}

/*<Codenesium>
    <Hash>7423c0d0548d64a441f31d97c7fd4ab0</Hash>
</Codenesium>*/