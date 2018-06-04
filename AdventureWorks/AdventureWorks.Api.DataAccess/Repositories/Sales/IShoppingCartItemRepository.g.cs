using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShoppingCartItemRepository
	{
		Task<ShoppingCartItem> Create(ShoppingCartItem item);

		Task Update(ShoppingCartItem item);

		Task Delete(int shoppingCartItemID);

		Task<ShoppingCartItem> Get(int shoppingCartItemID);

		Task<List<ShoppingCartItem>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ShoppingCartItem>> GetShoppingCartIDProductID(string shoppingCartID,int productID);
	}
}

/*<Codenesium>
    <Hash>6799e0c3ff416a22ffe806a148bfa19a</Hash>
</Codenesium>*/