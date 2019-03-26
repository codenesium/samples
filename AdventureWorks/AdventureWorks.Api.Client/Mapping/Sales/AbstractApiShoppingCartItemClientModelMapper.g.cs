using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiShoppingCartItemModelMapper
	{
		public virtual ApiShoppingCartItemClientResponseModel MapClientRequestToResponse(
			int shoppingCartItemID,
			ApiShoppingCartItemClientRequestModel request)
		{
			var response = new ApiShoppingCartItemClientResponseModel();
			response.SetProperties(shoppingCartItemID,
			                       request.DateCreated,
			                       request.ModifiedDate,
			                       request.ProductID,
			                       request.Quantity,
			                       request.ShoppingCartID);
			return response;
		}

		public virtual ApiShoppingCartItemClientRequestModel MapClientResponseToRequest(
			ApiShoppingCartItemClientResponseModel response)
		{
			var request = new ApiShoppingCartItemClientRequestModel();
			request.SetProperties(
				response.DateCreated,
				response.ModifiedDate,
				response.ProductID,
				response.Quantity,
				response.ShoppingCartID);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>9db0c6134c7e166d219e84b39fce6437</Hash>
</Codenesium>*/