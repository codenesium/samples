using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IShoppingCartItemRepository
	{
		Task<ShoppingCartItem> Create(ShoppingCartItem item);

		Task Update(ShoppingCartItem item);

		Task Delete(int shoppingCartItemID);

		Task<ShoppingCartItem> Get(int shoppingCartItemID);

		Task<List<ShoppingCartItem>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ShoppingCartItem>> ByShoppingCartIDProductID(string shoppingCartID, int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8c585d9e5e5e2e538c1666e2bbaa8d97</Hash>
</Codenesium>*/