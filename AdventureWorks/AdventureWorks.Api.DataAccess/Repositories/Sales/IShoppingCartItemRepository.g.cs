using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShoppingCartItemRepository
	{
		int Create(
			string shoppingCartID,
			int quantity,
			int productID,
			DateTime dateCreated,
			DateTime modifiedDate);

		void Update(int shoppingCartItemID,
		            string shoppingCartID,
		            int quantity,
		            int productID,
		            DateTime dateCreated,
		            DateTime modifiedDate);

		void Delete(int shoppingCartItemID);

		Response GetById(int shoppingCartItemID);

		POCOShoppingCartItem GetByIdDirect(int shoppingCartItemID);

		Response GetWhere(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOShoppingCartItem> GetWhereDirect(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>72a1c350c70febbd873761a1d0ddd754</Hash>
</Codenesium>*/