using System;
using System.Collections.Generic;

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
        }
}

/*<Codenesium>
    <Hash>bc8aef473e66ffd0b0d0b110ffb397cc</Hash>
</Codenesium>*/