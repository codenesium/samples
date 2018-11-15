using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiShoppingCartItemServerModelMapper
	{
		public virtual ApiShoppingCartItemServerResponseModel MapServerRequestToResponse(
			int shoppingCartItemID,
			ApiShoppingCartItemServerRequestModel request)
		{
			var response = new ApiShoppingCartItemServerResponseModel();
			response.SetProperties(shoppingCartItemID,
			                       request.DateCreated,
			                       request.ModifiedDate,
			                       request.ProductID,
			                       request.Quantity,
			                       request.ShoppingCartID);
			return response;
		}

		public virtual ApiShoppingCartItemServerRequestModel MapServerResponseToRequest(
			ApiShoppingCartItemServerResponseModel response)
		{
			var request = new ApiShoppingCartItemServerRequestModel();
			request.SetProperties(
				response.DateCreated,
				response.ModifiedDate,
				response.ProductID,
				response.Quantity,
				response.ShoppingCartID);
			return request;
		}

		public virtual ApiShoppingCartItemClientRequestModel MapServerResponseToClientRequest(
			ApiShoppingCartItemServerResponseModel response)
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

		public JsonPatchDocument<ApiShoppingCartItemServerRequestModel> CreatePatch(ApiShoppingCartItemServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiShoppingCartItemServerRequestModel>();
			patch.Replace(x => x.DateCreated, model.DateCreated);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.ProductID, model.ProductID);
			patch.Replace(x => x.Quantity, model.Quantity);
			patch.Replace(x => x.ShoppingCartID, model.ShoppingCartID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>19faddaf714fbfd11c42e694c8559cae</Hash>
</Codenesium>*/