using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>ad2eb2692bcac6f78e3635afc9737f4c</Hash>
</Codenesium>*/