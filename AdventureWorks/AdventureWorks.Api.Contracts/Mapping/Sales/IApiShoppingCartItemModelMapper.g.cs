using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiShoppingCartItemModelMapper
        {
                ApiShoppingCartItemResponseModel MapRequestToResponse(
                        int shoppingCartItemID,
                        ApiShoppingCartItemRequestModel request);

                ApiShoppingCartItemRequestModel MapResponseToRequest(
                        ApiShoppingCartItemResponseModel response);

                JsonPatchDocument<ApiShoppingCartItemRequestModel> CreatePatch(ApiShoppingCartItemRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e1b91540d4fb3fe90991791b2bcb0e2d</Hash>
</Codenesium>*/