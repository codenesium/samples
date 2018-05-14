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

		POCOShoppingCartItem Get(int shoppingCartItemID);

		List<POCOShoppingCartItem> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShoppingCartItem> GetShoppingCartIDProductID(string shoppingCartID,int productID);
	}
}

/*<Codenesium>
    <Hash>deb03fb0dc1f8f12940b152935239dbe</Hash>
</Codenesium>*/