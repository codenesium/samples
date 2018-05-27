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
		Task<CreateResponse<ApiShoppingCartItemResponseModel>> Create(
			ApiShoppingCartItemRequestModel model);

		Task<ActionResponse> Update(int shoppingCartItemID,
		                            ApiShoppingCartItemRequestModel model);

		Task<ActionResponse> Delete(int shoppingCartItemID);

		Task<ApiShoppingCartItemResponseModel> Get(int shoppingCartItemID);

		Task<List<ApiShoppingCartItemResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiShoppingCartItemResponseModel>> GetShoppingCartIDProductID(string shoppingCartID,int productID);
	}
}

/*<Codenesium>
    <Hash>559b2811e5112e262affaf0c36e2d8b9</Hash>
</Codenesium>*/