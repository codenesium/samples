using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiShoppingCartItemModelMapper
        {
                public virtual ApiShoppingCartItemResponseModel MapRequestToResponse(
                        int shoppingCartItemID,
                        ApiShoppingCartItemRequestModel request)
                {
                        var response = new ApiShoppingCartItemResponseModel();
                        response.SetProperties(shoppingCartItemID,
                                               request.DateCreated,
                                               request.ModifiedDate,
                                               request.ProductID,
                                               request.Quantity,
                                               request.ShoppingCartID);
                        return response;
                }

                public virtual ApiShoppingCartItemRequestModel MapResponseToRequest(
                        ApiShoppingCartItemResponseModel response)
                {
                        var request = new ApiShoppingCartItemRequestModel();
                        request.SetProperties(
                                response.DateCreated,
                                response.ModifiedDate,
                                response.ProductID,
                                response.Quantity,
                                response.ShoppingCartID);
                        return request;
                }

                public JsonPatchDocument<ApiShoppingCartItemRequestModel> CreatePatch(ApiShoppingCartItemRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiShoppingCartItemRequestModel>();
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
    <Hash>bebcddb20af369417697bcef88ac7b15</Hash>
</Codenesium>*/