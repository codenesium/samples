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

                Task<List<ApiPurchaseOrderDetailResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiPurchaseOrderDetailResponseModel>> GetProductID(int productID);
        }
}

/*<Codenesium>
    <Hash>ab9f32d6a3459ace7926ba677d7a4efc</Hash>
</Codenesium>*/