using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiShoppingCartItemModelMapper
        {
                ApiShoppingCartItemResponseModel MapRequestToResponse(
                        int shoppingCartItemID,
                        ApiShoppingCartItemRequestModel request);

                ApiShoppingCartItemRequestModel MapResponseToRequest(
                        ApiShoppingCartItemResponseModel response);
        }
}

/*<Codenesium>
    <Hash>4cb60a1e176d27b68d9bbdc659be6ec7</Hash>
</Codenesium>*/