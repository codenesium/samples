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
		Task<CreateResponse<int>> Create(
			ShoppingCartItemModel model);

		Task<ActionResponse> Update(int shoppingCartItemID,
		                            ShoppingCartItemModel model);

		Task<ActionResponse> Delete(int shoppingCartItemID);

		POCOShoppingCartItem Get(int shoppingCartItemID);

		List<POCOShoppingCartItem> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6e242b066d6cafa828f1e88f94955827</Hash>
</Codenesium>*/