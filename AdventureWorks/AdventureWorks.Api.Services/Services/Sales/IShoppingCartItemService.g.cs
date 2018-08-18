using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IShoppingCartItemService
	{
		Task<CreateResponse<ApiShoppingCartItemResponseModel>> Create(
			ApiShoppingCartItemRequestModel model);

		Task<UpdateResponse<ApiShoppingCartItemResponseModel>> Update(int shoppingCartItemID,
		                                                               ApiShoppingCartItemRequestModel model);

		Task<ActionResponse> Delete(int shoppingCartItemID);

		Task<ApiShoppingCartItemResponseModel> Get(int shoppingCartItemID);

		Task<List<ApiShoppingCartItemResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiShoppingCartItemResponseModel>> ByShoppingCartIDProductID(string shoppingCartID, int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fcf642ee8804a7e3df6969caa9edc9f6</Hash>
</Codenesium>*/