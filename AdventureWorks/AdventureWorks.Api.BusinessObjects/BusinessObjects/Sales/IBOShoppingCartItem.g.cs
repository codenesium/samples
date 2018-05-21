using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOShoppingCartItem
	{
		Task<CreateResponse<POCOShoppingCartItem>> Create(
			ApiShoppingCartItemModel model);

		Task<ActionResponse> Update(int shoppingCartItemID,
		                            ApiShoppingCartItemModel model);

		Task<ActionResponse> Delete(int shoppingCartItemID);

		Task<POCOShoppingCartItem> Get(int shoppingCartItemID);

		Task<List<POCOShoppingCartItem>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOShoppingCartItem>> GetShoppingCartIDProductID(string shoppingCartID,int productID);
	}
}

/*<Codenesium>
    <Hash>e04d2809ade9948216260e1e1616fea1</Hash>
</Codenesium>*/