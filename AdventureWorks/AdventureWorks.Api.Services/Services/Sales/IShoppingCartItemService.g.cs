using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>ea7456db6f2fe65dc18aa68505812d57</Hash>
</Codenesium>*/