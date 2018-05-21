using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShoppingCartItemRepository
	{
		Task<POCOShoppingCartItem> Create(ApiShoppingCartItemModel model);

		Task Update(int shoppingCartItemID,
		            ApiShoppingCartItemModel model);

		Task Delete(int shoppingCartItemID);

		Task<POCOShoppingCartItem> Get(int shoppingCartItemID);

		Task<List<POCOShoppingCartItem>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOShoppingCartItem>> GetShoppingCartIDProductID(string shoppingCartID,int productID);
	}
}

/*<Codenesium>
    <Hash>55c80ef5ecc6bcf902a8cadebda05b70</Hash>
</Codenesium>*/