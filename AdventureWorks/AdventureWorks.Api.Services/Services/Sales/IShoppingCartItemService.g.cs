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

		Task<List<ApiShoppingCartItemServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiShoppingCartItemServerResponseModel>> ByShoppingCartIDProductID(string shoppingCartID, int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>acf0ae4c5565c94e621a9d7df4eb27db</Hash>
</Codenesium>*/