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

		Task<List<ShoppingCartItem>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ShoppingCartItem>> ByShoppingCartIDProductID(string shoppingCartID, int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7784096d38a388dc632458f3ee81c74a</Hash>
</Codenesium>*/