using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IShoppingCartItemRepository
	{
		int Create(string shoppingCartID,
		           int quantity,
		           int productID,
		           DateTime dateCreated,
		           DateTime modifiedDate);

		void Update(int shoppingCartItemID, string shoppingCartID,
		            int quantity,
		            int productID,
		            DateTime dateCreated,
		            DateTime modifiedDate);

		void Delete(int shoppingCartItemID);

		void GetById(int shoppingCartItemID, Response response);

		void GetWhere(Expression<Func<EFShoppingCartItem, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d1f886277b951e95e9ccfb61b3c04b51</Hash>
</Codenesium>*/