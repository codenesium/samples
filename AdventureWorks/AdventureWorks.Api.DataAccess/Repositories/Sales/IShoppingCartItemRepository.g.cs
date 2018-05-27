using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShoppingCartItemRepository
	{
		Task<DTOShoppingCartItem> Create(DTOShoppingCartItem dto);

		Task Update(int shoppingCartItemID,
		            DTOShoppingCartItem dto);

		Task Delete(int shoppingCartItemID);

		Task<DTOShoppingCartItem> Get(int shoppingCartItemID);

		Task<List<DTOShoppingCartItem>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOShoppingCartItem>> GetShoppingCartIDProductID(string shoppingCartID,int productID);
	}
}

/*<Codenesium>
    <Hash>c31c9c1796959a70492c79847104b647</Hash>
</Codenesium>*/