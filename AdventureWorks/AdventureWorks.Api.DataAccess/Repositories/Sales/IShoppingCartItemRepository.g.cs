using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShoppingCartItemRepository
	{
		Task<ShoppingCartItem> Create(ShoppingCartItem item);

		Task Update(ShoppingCartItem item);

		Task Delete(int shoppingCartItemID);

		Task<ShoppingCartItem> Get(int shoppingCartItemID);

		Task<List<ShoppingCartItem>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ShoppingCartItem>> ByShoppingCartIDProductID(string shoppingCartID, int productID);
	}
}

/*<Codenesium>
    <Hash>6132a009550c428d3e119d0d711f7500</Hash>
</Codenesium>*/