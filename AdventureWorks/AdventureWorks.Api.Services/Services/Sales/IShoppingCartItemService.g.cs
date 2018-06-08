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

                Task<List<ApiShoppingCartItemResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiShoppingCartItemResponseModel>> GetShoppingCartIDProductID(string shoppingCartID, int productID);
        }
}

/*<Codenesium>
    <Hash>09c7e8fdbc209c7b1ee322bfa4181139</Hash>
</Codenesium>*/