using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IShoppingCartItemService
	{
		Task<CreateResponse<ApiShoppingCartItemServerResponseModel>> Create(
			ApiShoppingCartItemServerRequestModel model);

		Task<UpdateResponse<ApiShoppingCartItemServerResponseModel>> Update(int shoppingCartItemID,
		                                                                     ApiShoppingCartItemServerRequestModel model);

		Task<ActionResponse> Delete(int shoppingCartItemID);

		Task<ApiShoppingCartItemServerResponseModel> Get(int shoppingCartItemID);

		Task<List<ApiShoppingCartItemServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiShoppingCartItemServerResponseModel>> ByShoppingCartIDProductID(string shoppingCartID, int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fdf4d877f7187caff502a75a5e7089f4</Hash>
</Codenesium>*/