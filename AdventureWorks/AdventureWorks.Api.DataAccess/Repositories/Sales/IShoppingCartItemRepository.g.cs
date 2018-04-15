using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShoppingCartItemRepository
	{
		int Create(ShoppingCartItemModel model);

		void Update(int shoppingCartItemID,
		            ShoppingCartItemModel model);

		void Delete(int shoppingCartItemID);

		ApiResponse GetById(int shoppingCartItemID);

		POCOShoppingCartItem GetByIdDirect(int shoppingCartItemID);

		ApiResponse GetWhere(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShoppingCartItem> GetWhereDirect(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8e604ec10b203599e1437f925fe13d72</Hash>
</Codenesium>*/