using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLShoppingCartItemMapper
        {
                BOShoppingCartItem MapModelToBO(
                        int shoppingCartItemID,
                        ApiShoppingCartItemRequestModel model);

                ApiShoppingCartItemResponseModel MapBOToModel(
                        BOShoppingCartItem boShoppingCartItem);

                List<ApiShoppingCartItemResponseModel> MapBOToModel(
                        List<BOShoppingCartItem> items);
        }
}

/*<Codenesium>
    <Hash>5e1ad454c8bcdcf8a6ac98ee13e48564</Hash>
</Codenesium>*/