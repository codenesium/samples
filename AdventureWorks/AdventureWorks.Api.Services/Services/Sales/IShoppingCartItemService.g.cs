using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IShoppingCartItemService
        {
                Task<CreateResponse<ApiShoppingCartItemResponseModel>> Create(
                        ApiShoppingCartItemRequestModel model);

                Task<ActionResponse> Update(int shoppingCartItemID,
                                            ApiShoppingCartItemRequestModel model);

                Task<ActionResponse> Delete(int shoppingCartItemID);

                Task<ApiShoppingCartItemResponseModel> Get(int shoppingCartItemID);

                Task<List<ApiShoppingCartItemResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiShoppingCartItemResponseModel>> ByShoppingCartIDProductID(string shoppingCartID, int productID);
        }
}

/*<Codenesium>
    <Hash>b0ae770558e91cf2c54813e816c1c0e6</Hash>
</Codenesium>*/