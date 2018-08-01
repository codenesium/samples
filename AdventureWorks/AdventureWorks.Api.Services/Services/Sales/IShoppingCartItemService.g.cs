using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IShoppingCartItemService
	{
		Task<CreateResponse<ApiShoppingCartItemResponseModel>> Create(
			ApiShoppingCartItemRequestModel model);

		Task<UpdateResponse<ApiShoppingCartItemResponseModel>> Update(int shoppingCartItemID,
		                                                               ApiShoppingCartItemRequestModel model);

		Task<ActionResponse> Delete(int shoppingCartItemID);

		Task<ApiShoppingCartItemResponseModel> Get(int shoppingCartItemID);

		Task<List<ApiShoppingCartItemResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiShoppingCartItemResponseModel>> ByShoppingCartIDProductID(string shoppingCartID, int productID);
	}
}

/*<Codenesium>
    <Hash>27a280d3de7607b44fe06eb86b042964</Hash>
</Codenesium>*/