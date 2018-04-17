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

		ApiResponse GetById(int shoppingCartItemID);

		POCOShoppingCartItem GetByIdDirect(int shoppingCartItemID);

		ApiResponse GetWhere(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShoppingCartItem> GetWhereDirect(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2fe5fd29e66ad6baeb3db157178e52f7</Hash>
</Codenesium>*/