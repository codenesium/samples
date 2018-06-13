using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IPurchaseOrderDetailService
        {
                Task<CreateResponse<ApiPurchaseOrderDetailResponseModel>> Create(
                        ApiPurchaseOrderDetailRequestModel model);

                Task<ActionResponse> Update(int purchaseOrderID,
                                            ApiPurchaseOrderDetailRequestModel model);

                Task<ActionResponse> Delete(int purchaseOrderID);

                Task<ApiPurchaseOrderDetailResponseModel> Get(int purchaseOrderID);

                Task<List<ApiPurchaseOrderDetailResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiPurchaseOrderDetailResponseModel>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>4cccb5a64fbd31017f7f7b84d979fc10</Hash>
</Codenesium>*/